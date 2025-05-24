using FluentAssertions;
using Moq;
using TeamTrain.Application.DTOs.Tenant.Auth;
using TeamTrain.Application.Helpers;
using TeamTrain.Application.Interfaces.Tenant.Auth;
using TeamTrain.Application.Services.Tenant.Auth;
using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Interfaces.Repositories;
using TeamTrain.Domain.Interfaces.UnitOfWork;

namespace TeamTrain.Application.Tests;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock = new();
    private readonly Mock<IRefreshTokenRepository> _refreshTokenRepoMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ITokenService> _tokenServiceMock = new();

    private readonly AuthService _sut;

    public AuthServiceTests()
    {
        _sut = new AuthService(
            _userRepoMock.Object,
            _refreshTokenRepoMock.Object,
            _unitOfWorkMock.Object,
            _tokenServiceMock.Object
        );
    }

    [Fact]
    public async Task RegisterAsync_ShouldRegisterUser_WhenEmailIsAvailable()
    {
        // Arrange
        var dto = new RegisterDto("new@user.com", "password");

        _userRepoMock.Setup(x => x.EmailExistsAsync(dto.Email)).ReturnsAsync(false);
        _tokenServiceMock.Setup(x => x.GenerateAccessToken(It.IsAny<User>())).Returns("access-token");
        _tokenServiceMock.Setup(x => x.GenerateRefreshToken(It.IsAny<User>())).Returns("refresh-token");

        // Act
        var result = await _sut.RegisterAsync(dto);

        // Assert
        result.Success.Should().BeTrue();
        result.Data.AccessToken.Should().Be("access-token");
        result.Data.RefreshToken.Should().Be("refresh-token");

        _userRepoMock.Verify(x => x.AddAsync(It.Is<User>(u => u.Email == dto.Email)), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task RegisterAsync_ShouldFail_WhenEmailAlreadyExists()
    {
        var dto = new RegisterDto("exists@user.com", "password");
        _userRepoMock.Setup(x => x.EmailExistsAsync(dto.Email)).ReturnsAsync(true);

        var result = await _sut.RegisterAsync(dto);

        result.Success.Should().BeFalse();
        result.Message.Should().Contain("already");

        _userRepoMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Never);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnTokens_WhenCredentialsAreCorrect()
    {
        var dto = new LoginDto("valid@user.com", "password");
        var hashedPassword = PasswordHasher.HashPassword(dto.Password);
        var user = new User { Id = Guid.NewGuid(), Email = dto.Email, PasswordHash = hashedPassword };

        _userRepoMock.Setup(x => x.GetByEmailAsync(dto.Email)).ReturnsAsync(user);
        _tokenServiceMock.Setup(x => x.GenerateAccessToken(user)).Returns("access-token");
        _tokenServiceMock.Setup(x => x.GenerateRefreshToken(user)).Returns("refresh-token");

        var result = await _sut.LoginAsync(dto);

        result.Success.Should().BeTrue();
        result.Data.AccessToken.Should().Be("access-token");
        result.Data.RefreshToken.Should().Be("refresh-token");
    }

    [Fact]
    public async Task LoginAsync_ShouldFail_WhenUserNotFound()
    {
        var dto = new LoginDto ("notfound@user.com", "password");
        _userRepoMock.Setup(x => x.GetByEmailAsync(dto.Email)).ReturnsAsync((User)null!);

        var result = await _sut.LoginAsync(dto);

        result.Success.Should().BeFalse();
        result.Message.Should().Contain("Invalid");
    }

    [Fact]
    public async Task LoginAsync_ShouldFail_WhenPasswordIsWrong()
    {
        var dto = new LoginDto("user@domain.com", "wrong");
        var user = new User { Id = Guid.NewGuid(), Email = dto.Email, PasswordHash = PasswordHasher.HashPassword("correct") };

        _userRepoMock.Setup(x => x.GetByEmailAsync(dto.Email)).ReturnsAsync(user);

        var result = await _sut.LoginAsync(dto);

        result.Success.Should().BeFalse();
        result.Message.Should().Contain("Invalid");
    }

    [Fact]
    public void PasswordHasher_Should_Verify_Valid_Password()
    {
        var password = "secret123";
        var hash = PasswordHasher.HashPassword(password);

        var result = PasswordHasher.VerifyPasswordHash(password, hash);
        result.Should().BeTrue();
    }

    [Fact]
    public async Task RefreshTokenAsync_ShouldReturnNewTokens_WhenTokenIsValid()
    {
        var refreshToken = "valid-refresh-token";
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Email = "user@domain.com" };

        _refreshTokenRepoMock.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(new Domain.Entities.Auth.RefreshToken
        {
            Token = refreshToken,
            UserId = userId
        });

        _userRepoMock.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync(user);
        _tokenServiceMock.Setup(x => x.GenerateAccessToken(user)).Returns("new-access-token");
        _tokenServiceMock.Setup(x => x.GenerateRefreshToken(user)).Returns("new-refresh-token");

        var result = await _sut.RefreshTokenAsync(refreshToken);

        result.Success.Should().BeTrue();
        result.Data.AccessToken.Should().Be("new-access-token");
        result.Data.RefreshToken.Should().Be("new-refresh-token");
    }

    [Fact]
    public async Task RefreshTokenAsync_ShouldFail_WhenTokenIsInvalid()
    {
        var refreshToken = "invalid-token";
        _refreshTokenRepoMock.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync((Domain.Entities.Auth.RefreshToken)null!);

        var result = await _sut.RefreshTokenAsync(refreshToken);

        result.Success.Should().BeFalse();
        result.Message.Should().Contain("Invalid");
    }

    [Fact]
    public async Task RefreshTokenAsync_ShouldFail_WhenUserNotFound()
    {
        var refreshToken = "some-token";
        var userId = Guid.NewGuid();

        _refreshTokenRepoMock.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(new Domain.Entities.Auth.RefreshToken
        {
            Token = refreshToken,
            UserId = userId
        });

        _userRepoMock.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync((User)null!);

        var result = await _sut.RefreshTokenAsync(refreshToken);

        result.Success.Should().BeFalse();
        result.Message.Should().Contain("User not found");
    }
}

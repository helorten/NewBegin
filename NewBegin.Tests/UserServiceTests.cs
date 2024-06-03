using NewBegin.Services;
using NUnit;
using NUnit.Framework;

namespace NewBegin.Tests
{
    public class UserServiceTests
    {
        [Test]
        public async Task EmailValidatorTest()
        {
            //Valid addresses
            Assert.That(await EmailValidator.IsValidEmailAsync("test@gmail.com"));
            Assert.That(await EmailValidator.IsValidEmailAsync("test@yandex.ru"));
            Assert.That(await EmailValidator.IsValidEmailAsync("test.m@mail.ru"));
            Assert.That(await EmailValidator.IsValidEmailAsync("test@outlook.com"));
            Assert.That(await EmailValidator.IsValidEmailAsync("test.test@outlook.com"));
            Assert.That(await EmailValidator.IsValidEmailAsync("test@yahoo.com"));
            Assert.That(await EmailValidator.IsValidEmailAsync("test@bk.ru"));
            Assert.That(await EmailValidator.IsValidEmailAsync("test@test.test"));

            //Not valid adresses
            Assert.That(!await EmailValidator.IsValidEmailAsync("@gmail.com"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("testgmail.com"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test@gmail"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test@.com"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("@.com"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test@.com"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test@."));
            Assert.That(!await EmailValidator.IsValidEmailAsync("_@_.__"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test@@test.test"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("_@_.test"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("_@_.___"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test .test@test.test"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test . test@test . test"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test. test @test.test"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test.test @ test.test"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test .test@test.test"));
            Assert.That(!await EmailValidator.IsValidEmailAsync("test. test@test. test"));
        }
    }
}

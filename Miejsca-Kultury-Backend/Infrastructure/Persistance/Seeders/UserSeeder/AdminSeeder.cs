using System.Security.Claims;
using Application.CQRS.Account.Static;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Seeders.UserSeeder;

public class AdminSeeder
{
    private const string Email = "admin@admin.com";
    private const string Password = "ZAQ!2wsxCDE#4rfv";
    private const string Name = "Admin";

    internal static async Task SeedAssync(UserManager<Users> userManager, MiejscaKulturyDbContext context, CancellationToken cancellationToken)
    {
        var isUserExist = await userManager.Users.AnyAsync(x => x.Email == Email, cancellationToken);
        if(isUserExist) return;

        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var user = new Users()
        {
            Email = Email,
            UserName = Email,
            Name = Name,
            Surname = Name
        };

        var createdUser = await userManager.CreateAsync(user, Password);
        if (!createdUser.Succeeded) throw new BadRequestException("Nie dodano użytkownika!");

        var addUserRole = await userManager.AddToRoleAsync(user, UserRoles.User);
        if (!addUserRole.Succeeded) throw new BadRequestException("Nie dodano roli użytkownika!");

        var addAdminRole = await userManager.AddToRoleAsync(user, UserRoles.Admin);
        if (!addAdminRole.Succeeded) throw new BadRequestException("Nie dodano roli admina!");

        var addEmailClaim = await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
        if (!addEmailClaim.Succeeded) throw new BadRequestException("Nie dodano claimów emaila");

        var addIdentifier =
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        if (!addIdentifier.Succeeded) throw new BadRequestException("Nie dodano claimów id");

        await context.SaveChangesAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);
    }
}
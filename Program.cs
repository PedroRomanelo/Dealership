using Dealership.Extensions;
using Dealership.Repository.Implementations;
using Dealership.Repository.Interfaces;
using Dealership.Service.Implementations;
using Dealership.Service.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]!);

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddFluentValidationConfig();


builder.Services.AddHttpClient<IEmailService, EmailService>();
builder.Services.AddScoped<IAuthAdminService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordRecoveryTokenService, PasswordRecoveryTokenService>();
builder.Services.AddScoped<IAdminUserRepository>(provider => new AdminUserRepository(connectionString!));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository>(provider => new UserRepository(connectionString!));

builder.Services.AddScoped<IAddressRepository>(p => new AddressRepository(connectionString!));
builder.Services.AddScoped<IAddressService, AddressService>();

builder.Services.AddScoped<IModelRepository>(p => new ModelRepository(connectionString!));
builder.Services.AddScoped<IModelsService, ModelsService>();

builder.Services.AddScoped<IPaymentMethodRepository>(p => new PaymentMethodRepository(connectionString!));
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();

builder.Services.AddScoped<IInsuranceRepository>(p => new InsuranceRepository(connectionString!));
builder.Services.AddScoped<IInsuranceService, InsuranceService>();

builder.Services.AddScoped<IVehicleRepository>(p => new VehicleRepository(connectionString!));
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddScoped<IContractRepository>(p => new ContractRepository(connectionString!));
builder.Services.AddScoped<IContractsService, ContractsService>();

builder.Services.AddScoped<IReportRepository>(p => new ReportRepository(connectionString!));
builder.Services.AddScoped<IReportService, ReportService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolleyDamois.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terrain",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrain", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Terrain_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    Camping = table.Column<bool>(nullable: false),
                    Confirmation = table.Column<bool>(nullable: false),
                    PoolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confrontations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamAId = table.Column<int>(nullable: true),
                    TeamBId = table.Column<int>(nullable: true),
                    TeamRefereeId = table.Column<int>(nullable: true),
                    SetOneA = table.Column<int>(nullable: false),
                    SetOneB = table.Column<int>(nullable: false),
                    SetTwoA = table.Column<int>(nullable: false),
                    SetTwoB = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false, defaultValueSql: "Getdate()"),
                    TerrainNumber = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confrontations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confrontations_Teams_TeamAId",
                        column: x => x.TeamAId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confrontations_Teams_TeamBId",
                        column: x => x.TeamBId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confrontations_Teams_TeamRefereeId",
                        column: x => x.TeamRefereeId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confrontations_Terrain_TerrainNumber",
                        column: x => x.TerrainNumber,
                        principalTable: "Terrain",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliationNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Capitain = table.Column<bool>(nullable: false),
                    Reservist = table.Column<bool>(nullable: false),
                    Adress = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nationale" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Provinciale" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Loisir" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Camping", "CategoryId", "Confirmation", "Name", "PoolId" },
                values: new object[,]
                {
                    { 1, false, 1, false, "Equipe Nationale 1", null },
                    { 25, false, 2, false, "Equipe Provinciale 25", null },
                    { 27, false, 2, false, "Equipe Provinciale 27", null },
                    { 28, true, 2, false, "Equipe Provinciale 28", null },
                    { 29, false, 2, false, "Equipe Provinciale 29", null },
                    { 30, true, 2, false, "Equipe Provinciale 30", null },
                    { 31, false, 2, false, "Equipe Provinciale 31", null },
                    { 32, true, 2, false, "Equipe Provinciale 32", null },
                    { 33, false, 3, false, "Equipe Loisir 33", null },
                    { 34, true, 3, false, "Equipe Loisir 34", null },
                    { 35, false, 3, false, "Equipe Loisir 35", null },
                    { 36, true, 3, false, "Equipe Loisir 36", null },
                    { 37, false, 3, false, "Equipe Loisir 37", null },
                    { 38, true, 3, false, "Equipe Loisir 38", null },
                    { 39, false, 3, false, "Equipe Loisir 39", null },
                    { 40, true, 3, false, "Equipe Loisir 40", null },
                    { 41, false, 3, false, "Equipe Loisir 41", null },
                    { 42, true, 3, false, "Equipe Loisir 42", null },
                    { 43, false, 3, false, "Equipe Loisir 43", null },
                    { 44, true, 3, false, "Equipe Loisir 44", null },
                    { 45, false, 3, false, "Equipe Loisir 45", null },
                    { 46, true, 3, false, "Equipe Loisir 46", null },
                    { 47, false, 3, false, "Equipe Loisir 47", null },
                    { 48, true, 3, false, "Equipe Loisir 48", null },
                    { 24, true, 2, false, "Equipe Provinciale 24", null },
                    { 23, false, 2, false, "Equipe Provinciale 23", null },
                    { 26, true, 2, false, "Equipe Provinciale 26", null },
                    { 21, false, 2, false, "Equipe Provinciale 21", null },
                    { 2, true, 1, false, "Equipe Nationale 2", null },
                    { 3, false, 1, false, "Equipe Nationale 3", null },
                    { 4, true, 1, false, "Equipe Nationale 4", null },
                    { 5, false, 1, false, "Equipe Nationale 5", null },
                    { 6, true, 1, false, "Equipe Nationale 6", null },
                    { 7, false, 1, false, "Equipe Nationale 7", null },
                    { 8, true, 1, false, "Equipe Nationale 8", null },
                    { 9, false, 1, false, "Equipe Nationale 9", null },
                    { 10, true, 1, false, "Equipe Nationale 10", null },
                    { 11, false, 1, false, "Equipe Nationale 11", null },
                    { 12, true, 1, false, "Equipe Nationale 12", null },
                    { 13, false, 1, false, "Equipe Nationale 13", null },
                    { 22, true, 2, false, "Equipe Provinciale 22", null },
                    { 15, false, 1, false, "Equipe Nationale 15", null },
                    { 14, true, 1, false, "Equipe Nationale 14", null },
                    { 17, false, 2, false, "Equipe Provinciale 17", null },
                    { 20, true, 2, false, "Equipe Provinciale 20", null },
                    { 19, false, 2, false, "Equipe Provinciale 19", null },
                    { 18, true, 2, false, "Equipe Provinciale 18", null },
                    { 16, true, 1, false, "Equipe Nationale 16", null }
                });

            migrationBuilder.InsertData(
                table: "Terrain",
                columns: new[] { "Number", "CategoryId" },
                values: new object[,]
                {
                    { 10, 3 },
                    { 9, 3 },
                    { 11, 3 },
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 4, 1 },
                    { 12, 3 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "Adress", "AffiliationNumber", "Capitain", "Email", "Firstname", "Gender", "Lastname", "PhoneNumber", "Reservist", "TeamId" },
                values: new object[,]
                {
                    { 1, "Liège 1", "1", true, "mail1@mail.com", "Prénom N:1", "Male", "Nom N:1", "1", false, 1 },
                    { 195, "Liège 195", "195", false, "mail195@mail.com", "Prénom L:195", "Male", "Nom L:195", "195", true, 33 },
                    { 196, "Liège 196", "196", false, "mail196@mail.com", "Prénom L:196", "Female", "Nom L:196", "196", true, 33 },
                    { 197, "Liège 197", "197", false, "mail197@mail.com", "Prénom L:197", "Male", "Nom L:197", "197", true, 33 },
                    { 198, "Liège 198", "198", false, "mail198@mail.com", "Prénom L:198", "Female", "Nom L:198", "198", true, 33 },
                    { 199, "Liège 199", "199", false, "mail199@mail.com", "Prénom L:199", "Male", "Nom L:199", "199", false, 34 },
                    { 200, "Liège 200", "200", false, "mail200@mail.com", "Prénom L:200", "Female", "Nom L:200", "200", false, 34 },
                    { 201, "Liège 201", "201", false, "mail201@mail.com", "Prénom L:201", "Male", "Nom L:201", "201", false, 34 },
                    { 202, "Liège 202", "202", false, "mail202@mail.com", "Prénom L:202", "Female", "Nom L:202", "202", false, 34 },
                    { 203, "Liège 203", "203", false, "mail203@mail.com", "Prénom L:203", "Male", "Nom L:203", "203", false, 34 },
                    { 204, "Liège 204", "204", false, "mail204@mail.com", "Prénom L:204", "Female", "Nom L:204", "204", false, 34 },
                    { 205, "Liège 205", "205", false, "mail205@mail.com", "Prénom L:205", "Male", "Nom L:205", "205", false, 35 },
                    { 206, "Liège 206", "206", false, "mail206@mail.com", "Prénom L:206", "Female", "Nom L:206", "206", false, 35 },
                    { 207, "Liège 207", "207", false, "mail207@mail.com", "Prénom L:207", "Male", "Nom L:207", "207", false, 35 },
                    { 194, "Liège 194", "194", false, "mail194@mail.com", "Prénom L:194", "Female", "Nom L:194", "194", true, 33 },
                    { 208, "Liège 208", "208", false, "mail208@mail.com", "Prénom L:208", "Female", "Nom L:208", "208", false, 35 },
                    { 210, "Liège 210", "210", false, "mail210@mail.com", "Prénom L:210", "Female", "Nom L:210", "210", false, 35 },
                    { 211, "Liège 211", "211", false, "mail211@mail.com", "Prénom L:211", "Male", "Nom L:211", "211", true, 36 },
                    { 212, "Liège 212", "212", false, "mail212@mail.com", "Prénom L:212", "Female", "Nom L:212", "212", true, 36 },
                    { 213, "Liège 213", "213", false, "mail213@mail.com", "Prénom L:213", "Male", "Nom L:213", "213", true, 36 },
                    { 214, "Liège 214", "214", false, "mail214@mail.com", "Prénom L:214", "Female", "Nom L:214", "214", true, 36 },
                    { 215, "Liège 215", "215", false, "mail215@mail.com", "Prénom L:215", "Male", "Nom L:215", "215", true, 36 },
                    { 216, "Liège 216", "216", false, "mail216@mail.com", "Prénom L:216", "Female", "Nom L:216", "216", true, 36 },
                    { 217, "Liège 217", "217", false, "mail217@mail.com", "Prénom L:217", "Male", "Nom L:217", "217", false, 37 },
                    { 218, "Liège 218", "218", false, "mail218@mail.com", "Prénom L:218", "Female", "Nom L:218", "218", false, 37 },
                    { 219, "Liège 219", "219", false, "mail219@mail.com", "Prénom L:219", "Male", "Nom L:219", "219", false, 37 },
                    { 220, "Liège 220", "220", false, "mail220@mail.com", "Prénom L:220", "Female", "Nom L:220", "220", false, 37 },
                    { 221, "Liège 221", "221", false, "mail221@mail.com", "Prénom L:221", "Male", "Nom L:221", "221", false, 37 },
                    { 222, "Liège 222", "222", false, "mail222@mail.com", "Prénom L:222", "Female", "Nom L:222", "222", false, 37 },
                    { 209, "Liège 209", "209", false, "mail209@mail.com", "Prénom L:209", "Male", "Nom L:209", "209", false, 35 },
                    { 223, "Liège 223", "223", false, "mail223@mail.com", "Prénom L:223", "Male", "Nom L:223", "223", false, 38 },
                    { 193, "Liège 193", "193", false, "mail193@mail.com", "Prénom L:193", "Male", "Nom L:193", "193", true, 33 },
                    { 191, "Liège 191", "191", false, "mail191@mail.com", "Prénom P:191", "Male", "Nom P:191", "191", false, 32 },
                    { 163, "Liège 163", "163", false, "mail163@mail.com", "Prénom P:163", "Male", "Nom P:163", "163", false, 28 },
                    { 164, "Liège 164", "164", false, "mail164@mail.com", "Prénom P:164", "Female", "Nom P:164", "164", false, 28 },
                    { 165, "Liège 165", "165", false, "mail165@mail.com", "Prénom P:165", "Male", "Nom P:165", "165", false, 28 },
                    { 166, "Liège 166", "166", false, "mail166@mail.com", "Prénom P:166", "Female", "Nom P:166", "166", false, 28 },
                    { 167, "Liège 167", "167", false, "mail167@mail.com", "Prénom P:167", "Male", "Nom P:167", "167", false, 28 },
                    { 168, "Liège 168", "168", false, "mail168@mail.com", "Prénom P:168", "Female", "Nom P:168", "168", false, 28 },
                    { 169, "Liège 169", "169", false, "mail169@mail.com", "Prénom P:169", "Male", "Nom P:169", "169", false, 29 },
                    { 170, "Liège 170", "170", false, "mail170@mail.com", "Prénom P:170", "Female", "Nom P:170", "170", false, 29 },
                    { 171, "Liège 171", "171", false, "mail171@mail.com", "Prénom P:171", "Male", "Nom P:171", "171", false, 29 },
                    { 172, "Liège 172", "172", false, "mail172@mail.com", "Prénom P:172", "Female", "Nom P:172", "172", false, 29 },
                    { 173, "Liège 173", "173", false, "mail173@mail.com", "Prénom P:173", "Male", "Nom P:173", "173", false, 29 },
                    { 174, "Liège 174", "174", false, "mail174@mail.com", "Prénom P:174", "Female", "Nom P:174", "174", false, 29 },
                    { 175, "Liège 175", "175", false, "mail175@mail.com", "Prénom P:175", "Male", "Nom P:175", "175", true, 30 },
                    { 192, "Liège 192", "192", false, "mail192@mail.com", "Prénom P:192", "Female", "Nom P:192", "192", false, 32 },
                    { 176, "Liège 176", "176", false, "mail176@mail.com", "Prénom P:176", "Female", "Nom P:176", "176", true, 30 },
                    { 178, "Liège 178", "178", false, "mail178@mail.com", "Prénom P:178", "Female", "Nom P:178", "178", true, 30 },
                    { 179, "Liège 179", "179", false, "mail179@mail.com", "Prénom P:179", "Male", "Nom P:179", "179", true, 30 },
                    { 180, "Liège 180", "180", false, "mail180@mail.com", "Prénom P:180", "Female", "Nom P:180", "180", true, 30 },
                    { 181, "Liège 181", "181", false, "mail181@mail.com", "Prénom P:181", "Male", "Nom P:181", "181", false, 31 },
                    { 182, "Liège 182", "182", false, "mail182@mail.com", "Prénom P:182", "Female", "Nom P:182", "182", false, 31 },
                    { 183, "Liège 183", "183", false, "mail183@mail.com", "Prénom P:183", "Male", "Nom P:183", "183", false, 31 },
                    { 184, "Liège 184", "184", false, "mail184@mail.com", "Prénom P:184", "Female", "Nom P:184", "184", false, 31 },
                    { 185, "Liège 185", "185", false, "mail185@mail.com", "Prénom P:185", "Male", "Nom P:185", "185", false, 31 },
                    { 186, "Liège 186", "186", false, "mail186@mail.com", "Prénom P:186", "Female", "Nom P:186", "186", false, 31 },
                    { 187, "Liège 187", "187", false, "mail187@mail.com", "Prénom P:187", "Male", "Nom P:187", "187", false, 32 },
                    { 188, "Liège 188", "188", false, "mail188@mail.com", "Prénom P:188", "Female", "Nom P:188", "188", false, 32 },
                    { 189, "Liège 189", "189", false, "mail189@mail.com", "Prénom P:189", "Male", "Nom P:189", "189", false, 32 },
                    { 190, "Liège 190", "190", false, "mail190@mail.com", "Prénom P:190", "Female", "Nom P:190", "190", false, 32 },
                    { 177, "Liège 177", "177", false, "mail177@mail.com", "Prénom P:177", "Male", "Nom P:177", "177", true, 30 },
                    { 162, "Liège 162", "162", false, "mail162@mail.com", "Prénom P:162", "Female", "Nom P:162", "162", true, 27 },
                    { 224, "Liège 224", "224", false, "mail224@mail.com", "Prénom L:224", "Female", "Nom L:224", "224", false, 38 },
                    { 226, "Liège 226", "226", false, "mail226@mail.com", "Prénom L:226", "Female", "Nom L:226", "226", false, 38 },
                    { 259, "Liège 259", "259", false, "mail259@mail.com", "Prénom L:259", "Male", "Nom L:259", "259", false, 44 },
                    { 260, "Liège 260", "260", false, "mail260@mail.com", "Prénom L:260", "Female", "Nom L:260", "260", false, 44 },
                    { 261, "Liège 261", "261", false, "mail261@mail.com", "Prénom L:261", "Male", "Nom L:261", "261", false, 44 },
                    { 262, "Liège 262", "262", false, "mail262@mail.com", "Prénom L:262", "Female", "Nom L:262", "262", false, 44 },
                    { 263, "Liège 263", "263", false, "mail263@mail.com", "Prénom L:263", "Male", "Nom L:263", "263", false, 44 },
                    { 264, "Liège 264", "264", false, "mail264@mail.com", "Prénom L:264", "Female", "Nom L:264", "264", false, 44 },
                    { 265, "Liège 265", "265", false, "mail265@mail.com", "Prénom L:265", "Male", "Nom L:265", "265", true, 45 },
                    { 266, "Liège 266", "266", false, "mail266@mail.com", "Prénom L:266", "Female", "Nom L:266", "266", true, 45 },
                    { 267, "Liège 267", "267", false, "mail267@mail.com", "Prénom L:267", "Male", "Nom L:267", "267", true, 45 },
                    { 268, "Liège 268", "268", false, "mail268@mail.com", "Prénom L:268", "Female", "Nom L:268", "268", true, 45 },
                    { 269, "Liège 269", "269", false, "mail269@mail.com", "Prénom L:269", "Male", "Nom L:269", "269", true, 45 },
                    { 270, "Liège 270", "270", false, "mail270@mail.com", "Prénom L:270", "Female", "Nom L:270", "270", true, 45 },
                    { 271, "Liège 271", "271", false, "mail271@mail.com", "Prénom L:271", "Male", "Nom L:271", "271", false, 46 },
                    { 258, "Liège 258", "258", false, "mail258@mail.com", "Prénom L:258", "Female", "Nom L:258", "258", false, 43 },
                    { 272, "Liège 272", "272", false, "mail272@mail.com", "Prénom L:272", "Female", "Nom L:272", "272", false, 46 },
                    { 274, "Liège 274", "274", false, "mail274@mail.com", "Prénom L:274", "Female", "Nom L:274", "274", false, 46 },
                    { 275, "Liège 275", "275", false, "mail275@mail.com", "Prénom L:275", "Male", "Nom L:275", "275", false, 46 },
                    { 276, "Liège 276", "276", false, "mail276@mail.com", "Prénom L:276", "Female", "Nom L:276", "276", false, 46 },
                    { 277, "Liège 277", "277", false, "mail277@mail.com", "Prénom L:277", "Male", "Nom L:277", "277", false, 47 },
                    { 278, "Liège 278", "278", false, "mail278@mail.com", "Prénom L:278", "Female", "Nom L:278", "278", false, 47 },
                    { 279, "Liège 279", "279", false, "mail279@mail.com", "Prénom L:279", "Male", "Nom L:279", "279", false, 47 },
                    { 280, "Liège 280", "280", false, "mail280@mail.com", "Prénom L:280", "Female", "Nom L:280", "280", false, 47 },
                    { 281, "Liège 281", "281", false, "mail281@mail.com", "Prénom L:281", "Male", "Nom L:281", "281", false, 47 },
                    { 282, "Liège 282", "282", false, "mail282@mail.com", "Prénom L:282", "Female", "Nom L:282", "282", false, 47 },
                    { 283, "Liège 283", "283", false, "mail283@mail.com", "Prénom L:283", "Male", "Nom L:283", "283", true, 48 },
                    { 284, "Liège 284", "284", false, "mail284@mail.com", "Prénom L:284", "Female", "Nom L:284", "284", true, 48 },
                    { 285, "Liège 285", "285", false, "mail285@mail.com", "Prénom L:285", "Male", "Nom L:285", "285", true, 48 },
                    { 286, "Liège 286", "286", false, "mail286@mail.com", "Prénom L:286", "Female", "Nom L:286", "286", true, 48 },
                    { 273, "Liège 273", "273", false, "mail273@mail.com", "Prénom L:273", "Male", "Nom L:273", "273", false, 46 },
                    { 225, "Liège 225", "225", false, "mail225@mail.com", "Prénom L:225", "Male", "Nom L:225", "225", false, 38 },
                    { 257, "Liège 257", "257", false, "mail257@mail.com", "Prénom L:257", "Male", "Nom L:257", "257", false, 43 },
                    { 255, "Liège 255", "255", false, "mail255@mail.com", "Prénom L:255", "Male", "Nom L:255", "255", false, 43 },
                    { 227, "Liège 227", "227", false, "mail227@mail.com", "Prénom L:227", "Male", "Nom L:227", "227", false, 38 },
                    { 228, "Liège 228", "228", false, "mail228@mail.com", "Prénom L:228", "Female", "Nom L:228", "228", false, 38 },
                    { 229, "Liège 229", "229", false, "mail229@mail.com", "Prénom L:229", "Male", "Nom L:229", "229", true, 39 },
                    { 230, "Liège 230", "230", false, "mail230@mail.com", "Prénom L:230", "Female", "Nom L:230", "230", true, 39 },
                    { 231, "Liège 231", "231", false, "mail231@mail.com", "Prénom L:231", "Male", "Nom L:231", "231", true, 39 },
                    { 232, "Liège 232", "232", false, "mail232@mail.com", "Prénom L:232", "Female", "Nom L:232", "232", true, 39 },
                    { 233, "Liège 233", "233", false, "mail233@mail.com", "Prénom L:233", "Male", "Nom L:233", "233", true, 39 },
                    { 234, "Liège 234", "234", false, "mail234@mail.com", "Prénom L:234", "Female", "Nom L:234", "234", true, 39 },
                    { 235, "Liège 235", "235", false, "mail235@mail.com", "Prénom L:235", "Male", "Nom L:235", "235", false, 40 },
                    { 236, "Liège 236", "236", false, "mail236@mail.com", "Prénom L:236", "Female", "Nom L:236", "236", false, 40 },
                    { 237, "Liège 237", "237", false, "mail237@mail.com", "Prénom L:237", "Male", "Nom L:237", "237", false, 40 },
                    { 238, "Liège 238", "238", false, "mail238@mail.com", "Prénom L:238", "Female", "Nom L:238", "238", false, 40 },
                    { 239, "Liège 239", "239", false, "mail239@mail.com", "Prénom L:239", "Male", "Nom L:239", "239", false, 40 },
                    { 256, "Liège 256", "256", false, "mail256@mail.com", "Prénom L:256", "Female", "Nom L:256", "256", false, 43 },
                    { 240, "Liège 240", "240", false, "mail240@mail.com", "Prénom L:240", "Female", "Nom L:240", "240", false, 40 },
                    { 242, "Liège 242", "242", false, "mail242@mail.com", "Prénom L:242", "Female", "Nom L:242", "242", false, 41 },
                    { 243, "Liège 243", "243", false, "mail243@mail.com", "Prénom L:243", "Male", "Nom L:243", "243", false, 41 },
                    { 244, "Liège 244", "244", false, "mail244@mail.com", "Prénom L:244", "Female", "Nom L:244", "244", false, 41 },
                    { 245, "Liège 245", "245", false, "mail245@mail.com", "Prénom L:245", "Male", "Nom L:245", "245", false, 41 },
                    { 246, "Liège 246", "246", false, "mail246@mail.com", "Prénom L:246", "Female", "Nom L:246", "246", false, 41 },
                    { 247, "Liège 247", "247", false, "mail247@mail.com", "Prénom L:247", "Male", "Nom L:247", "247", true, 42 },
                    { 248, "Liège 248", "248", false, "mail248@mail.com", "Prénom L:248", "Female", "Nom L:248", "248", true, 42 },
                    { 249, "Liège 249", "249", false, "mail249@mail.com", "Prénom L:249", "Male", "Nom L:249", "249", true, 42 },
                    { 250, "Liège 250", "250", false, "mail250@mail.com", "Prénom L:250", "Female", "Nom L:250", "250", true, 42 },
                    { 251, "Liège 251", "251", false, "mail251@mail.com", "Prénom L:251", "Male", "Nom L:251", "251", true, 42 },
                    { 252, "Liège 252", "252", false, "mail252@mail.com", "Prénom L:252", "Female", "Nom L:252", "252", true, 42 },
                    { 253, "Liège 253", "253", false, "mail253@mail.com", "Prénom L:253", "Male", "Nom L:253", "253", false, 43 },
                    { 254, "Liège 254", "254", false, "mail254@mail.com", "Prénom L:254", "Female", "Nom L:254", "254", false, 43 },
                    { 241, "Liège 241", "241", false, "mail241@mail.com", "Prénom L:241", "Male", "Nom L:241", "241", false, 41 },
                    { 161, "Liège 161", "161", false, "mail161@mail.com", "Prénom P:161", "Male", "Nom P:161", "161", true, 27 },
                    { 160, "Liège 160", "160", false, "mail160@mail.com", "Prénom P:160", "Female", "Nom P:160", "160", true, 27 },
                    { 159, "Liège 159", "159", false, "mail159@mail.com", "Prénom P:159", "Male", "Nom P:159", "159", true, 27 },
                    { 34, "Liège 34", "34", false, "mail34@mail.com", "Prénom N:34", "Female", "Nom N:34", "34", true, 9 },
                    { 35, "Liège 35", "35", false, "mail35@mail.com", "Prénom N:35", "Male", "Nom N:35", "35", true, 9 },
                    { 36, "Liège 36", "36", false, "mail36@mail.com", "Prénom N:36", "Female", "Nom N:36", "36", true, 9 },
                    { 37, "Liège 37", "37", false, "mail37@mail.com", "Prénom N:37", "Male", "Nom N:37", "37", false, 10 },
                    { 38, "Liège 38", "38", false, "mail38@mail.com", "Prénom N:38", "Female", "Nom N:38", "38", false, 10 },
                    { 39, "Liège 39", "39", false, "mail39@mail.com", "Prénom N:39", "Male", "Nom N:39", "39", false, 10 },
                    { 40, "Liège 40", "40", false, "mail40@mail.com", "Prénom N:40", "Female", "Nom N:40", "40", false, 10 },
                    { 41, "Liège 41", "41", false, "mail41@mail.com", "Prénom N:41", "Male", "Nom N:41", "41", false, 11 },
                    { 42, "Liège 42", "42", false, "mail42@mail.com", "Prénom N:42", "Female", "Nom N:42", "42", false, 11 },
                    { 43, "Liège 43", "43", false, "mail43@mail.com", "Prénom N:43", "Male", "Nom N:43", "43", false, 11 },
                    { 44, "Liège 44", "44", false, "mail44@mail.com", "Prénom N:44", "Female", "Nom N:44", "44", false, 11 },
                    { 45, "Liège 45", "45", false, "mail45@mail.com", "Prénom N:45", "Male", "Nom N:45", "45", true, 12 },
                    { 46, "Liège 46", "46", false, "mail46@mail.com", "Prénom N:46", "Female", "Nom N:46", "46", true, 12 },
                    { 33, "Liège 33", "33", false, "mail33@mail.com", "Prénom N:33", "Male", "Nom N:33", "33", true, 9 },
                    { 47, "Liège 47", "47", false, "mail47@mail.com", "Prénom N:47", "Male", "Nom N:47", "47", true, 12 },
                    { 49, "Liège 49", "49", false, "mail49@mail.com", "Prénom N:49", "Male", "Nom N:49", "49", false, 13 },
                    { 50, "Liège 50", "50", false, "mail50@mail.com", "Prénom N:50", "Female", "Nom N:50", "50", false, 13 },
                    { 51, "Liège 51", "51", false, "mail51@mail.com", "Prénom N:51", "Male", "Nom N:51", "51", false, 13 },
                    { 52, "Liège 52", "52", false, "mail52@mail.com", "Prénom N:52", "Female", "Nom N:52", "52", false, 13 },
                    { 53, "Liège 53", "53", false, "mail53@mail.com", "Prénom N:53", "Male", "Nom N:53", "53", false, 14 },
                    { 54, "Liège 54", "54", false, "mail54@mail.com", "Prénom N:54", "Female", "Nom N:54", "54", false, 14 },
                    { 55, "Liège 55", "55", false, "mail55@mail.com", "Prénom N:55", "Male", "Nom N:55", "55", false, 14 },
                    { 56, "Liège 56", "56", false, "mail56@mail.com", "Prénom N:56", "Female", "Nom N:56", "56", false, 14 },
                    { 57, "Liège 57", "57", false, "mail57@mail.com", "Prénom N:57", "Male", "Nom N:57", "57", true, 15 },
                    { 58, "Liège 58", "58", false, "mail58@mail.com", "Prénom N:58", "Female", "Nom N:58", "58", true, 15 },
                    { 59, "Liège 59", "59", false, "mail59@mail.com", "Prénom N:59", "Male", "Nom N:59", "59", true, 15 },
                    { 60, "Liège 60", "60", false, "mail60@mail.com", "Prénom N:60", "Female", "Nom N:60", "60", true, 15 },
                    { 61, "Liège 61", "61", false, "mail61@mail.com", "Prénom N:61", "Male", "Nom N:61", "61", false, 16 },
                    { 48, "Liège 48", "48", false, "mail48@mail.com", "Prénom N:48", "Female", "Nom N:48", "48", true, 12 },
                    { 62, "Liège 62", "62", false, "mail62@mail.com", "Prénom N:62", "Female", "Nom N:62", "62", false, 16 },
                    { 32, "Liège 32", "32", false, "mail32@mail.com", "Prénom N:32", "Female", "Nom N:32", "32", false, 8 },
                    { 30, "Liège 30", "30", false, "mail30@mail.com", "Prénom N:30", "Female", "Nom N:30", "30", false, 8 },
                    { 2, "Liège 2", "2", true, "mail2@mail.com", "Prénom N:2", "Female", "Nom N:2", "2", false, 1 },
                    { 3, "Liège 3", "3", true, "mail3@mail.com", "Prénom N:3", "Male", "Nom N:3", "3", false, 1 },
                    { 4, "Liège 4", "4", true, "mail4@mail.com", "Prénom N:4", "Female", "Nom N:4", "4", false, 1 },
                    { 5, "Liège 5", "5", false, "mail5@mail.com", "Prénom N:5", "Male", "Nom N:5", "5", false, 2 },
                    { 6, "Liège 6", "6", false, "mail6@mail.com", "Prénom N:6", "Female", "Nom N:6", "6", false, 2 },
                    { 7, "Liège 7", "7", false, "mail7@mail.com", "Prénom N:7", "Male", "Nom N:7", "7", false, 2 },
                    { 8, "Liège 8", "8", false, "mail8@mail.com", "Prénom N:8", "Female", "Nom N:8", "8", false, 2 },
                    { 9, "Liège 9", "9", false, "mail9@mail.com", "Prénom N:9", "Male", "Nom N:9", "9", true, 3 },
                    { 10, "Liège 10", "10", false, "mail10@mail.com", "Prénom N:10", "Female", "Nom N:10", "10", true, 3 },
                    { 11, "Liège 11", "11", false, "mail11@mail.com", "Prénom N:11", "Male", "Nom N:11", "11", true, 3 },
                    { 12, "Liège 12", "12", false, "mail12@mail.com", "Prénom N:12", "Female", "Nom N:12", "12", true, 3 },
                    { 13, "Liège 13", "13", false, "mail13@mail.com", "Prénom N:13", "Male", "Nom N:13", "13", false, 4 },
                    { 14, "Liège 14", "14", false, "mail14@mail.com", "Prénom N:14", "Female", "Nom N:14", "14", false, 4 },
                    { 31, "Liège 31", "31", false, "mail31@mail.com", "Prénom N:31", "Male", "Nom N:31", "31", false, 8 },
                    { 15, "Liège 15", "15", false, "mail15@mail.com", "Prénom N:15", "Male", "Nom N:15", "15", false, 4 },
                    { 17, "Liège 17", "17", false, "mail17@mail.com", "Prénom N:17", "Male", "Nom N:17", "17", false, 5 },
                    { 18, "Liège 18", "18", false, "mail18@mail.com", "Prénom N:18", "Female", "Nom N:18", "18", false, 5 },
                    { 19, "Liège 19", "19", false, "mail19@mail.com", "Prénom N:19", "Male", "Nom N:19", "19", false, 5 },
                    { 20, "Liège 20", "20", false, "mail20@mail.com", "Prénom N:20", "Female", "Nom N:20", "20", false, 5 },
                    { 21, "Liège 21", "21", false, "mail21@mail.com", "Prénom N:21", "Male", "Nom N:21", "21", true, 6 },
                    { 22, "Liège 22", "22", false, "mail22@mail.com", "Prénom N:22", "Female", "Nom N:22", "22", true, 6 },
                    { 23, "Liège 23", "23", false, "mail23@mail.com", "Prénom N:23", "Male", "Nom N:23", "23", true, 6 },
                    { 24, "Liège 24", "24", false, "mail24@mail.com", "Prénom N:24", "Female", "Nom N:24", "24", true, 6 },
                    { 25, "Liège 25", "25", false, "mail25@mail.com", "Prénom N:25", "Male", "Nom N:25", "25", false, 7 },
                    { 26, "Liège 26", "26", false, "mail26@mail.com", "Prénom N:26", "Female", "Nom N:26", "26", false, 7 },
                    { 27, "Liège 27", "27", false, "mail27@mail.com", "Prénom N:27", "Male", "Nom N:27", "27", false, 7 },
                    { 28, "Liège 28", "28", false, "mail28@mail.com", "Prénom N:28", "Female", "Nom N:28", "28", false, 7 },
                    { 29, "Liège 29", "29", false, "mail29@mail.com", "Prénom N:29", "Male", "Nom N:29", "29", false, 8 },
                    { 16, "Liège 16", "16", false, "mail16@mail.com", "Prénom N:16", "Female", "Nom N:16", "16", false, 4 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "Adress", "AffiliationNumber", "Capitain", "Email", "Firstname", "Gender", "Lastname", "PhoneNumber", "Reservist", "TeamId" },
                values: new object[,]
                {
                    { 63, "Liège 63", "63", false, "mail63@mail.com", "Prénom N:63", "Male", "Nom N:63", "63", false, 16 },
                    { 64, "Liège 64", "64", false, "mail64@mail.com", "Prénom N:64", "Female", "Nom N:64", "64", false, 16 },
                    { 97, "Liège 97", "97", false, "mail97@mail.com", "Prénom P:97", "Male", "Nom P:97", "97", false, 17 },
                    { 131, "Liège 131", "131", false, "mail131@mail.com", "Prénom P:131", "Male", "Nom P:131", "131", false, 22 },
                    { 132, "Liège 132", "132", false, "mail132@mail.com", "Prénom P:132", "Female", "Nom P:132", "132", false, 22 },
                    { 133, "Liège 133", "133", false, "mail133@mail.com", "Prénom P:133", "Male", "Nom P:133", "133", false, 23 },
                    { 134, "Liège 134", "134", false, "mail134@mail.com", "Prénom P:134", "Female", "Nom P:134", "134", false, 23 },
                    { 135, "Liège 135", "135", false, "mail135@mail.com", "Prénom P:135", "Male", "Nom P:135", "135", false, 23 },
                    { 136, "Liège 136", "136", false, "mail136@mail.com", "Prénom P:136", "Female", "Nom P:136", "136", false, 23 },
                    { 137, "Liège 137", "137", false, "mail137@mail.com", "Prénom P:137", "Male", "Nom P:137", "137", false, 23 },
                    { 138, "Liège 138", "138", false, "mail138@mail.com", "Prénom P:138", "Female", "Nom P:138", "138", false, 23 },
                    { 139, "Liège 139", "139", false, "mail139@mail.com", "Prénom P:139", "Male", "Nom P:139", "139", true, 24 },
                    { 140, "Liège 140", "140", false, "mail140@mail.com", "Prénom P:140", "Female", "Nom P:140", "140", true, 24 },
                    { 141, "Liège 141", "141", false, "mail141@mail.com", "Prénom P:141", "Male", "Nom P:141", "141", true, 24 },
                    { 142, "Liège 142", "142", false, "mail142@mail.com", "Prénom P:142", "Female", "Nom P:142", "142", true, 24 },
                    { 143, "Liège 143", "143", false, "mail143@mail.com", "Prénom P:143", "Male", "Nom P:143", "143", true, 24 },
                    { 130, "Liège 130", "130", false, "mail130@mail.com", "Prénom P:130", "Female", "Nom P:130", "130", false, 22 },
                    { 144, "Liège 144", "144", false, "mail144@mail.com", "Prénom P:144", "Female", "Nom P:144", "144", true, 24 },
                    { 146, "Liège 146", "146", false, "mail146@mail.com", "Prénom P:146", "Female", "Nom P:146", "146", false, 25 },
                    { 147, "Liège 147", "147", false, "mail147@mail.com", "Prénom P:147", "Male", "Nom P:147", "147", false, 25 },
                    { 148, "Liège 148", "148", false, "mail148@mail.com", "Prénom P:148", "Female", "Nom P:148", "148", false, 25 },
                    { 149, "Liège 149", "149", false, "mail149@mail.com", "Prénom P:149", "Male", "Nom P:149", "149", false, 25 },
                    { 150, "Liège 150", "150", false, "mail150@mail.com", "Prénom P:150", "Female", "Nom P:150", "150", false, 25 },
                    { 151, "Liège 151", "151", false, "mail151@mail.com", "Prénom P:151", "Male", "Nom P:151", "151", false, 26 },
                    { 152, "Liège 152", "152", false, "mail152@mail.com", "Prénom P:152", "Female", "Nom P:152", "152", false, 26 },
                    { 153, "Liège 153", "153", false, "mail153@mail.com", "Prénom P:153", "Male", "Nom P:153", "153", false, 26 },
                    { 154, "Liège 154", "154", false, "mail154@mail.com", "Prénom P:154", "Female", "Nom P:154", "154", false, 26 },
                    { 155, "Liège 155", "155", false, "mail155@mail.com", "Prénom P:155", "Male", "Nom P:155", "155", false, 26 },
                    { 156, "Liège 156", "156", false, "mail156@mail.com", "Prénom P:156", "Female", "Nom P:156", "156", false, 26 },
                    { 157, "Liège 157", "157", false, "mail157@mail.com", "Prénom P:157", "Male", "Nom P:157", "157", true, 27 },
                    { 158, "Liège 158", "158", false, "mail158@mail.com", "Prénom P:158", "Female", "Nom P:158", "158", true, 27 },
                    { 145, "Liège 145", "145", false, "mail145@mail.com", "Prénom P:145", "Male", "Nom P:145", "145", false, 25 },
                    { 129, "Liège 129", "129", false, "mail129@mail.com", "Prénom P:129", "Male", "Nom P:129", "129", false, 22 },
                    { 128, "Liège 128", "128", false, "mail128@mail.com", "Prénom P:128", "Female", "Nom P:128", "128", false, 22 },
                    { 127, "Liège 127", "127", false, "mail127@mail.com", "Prénom P:127", "Male", "Nom P:127", "127", false, 22 },
                    { 98, "Liège 98", "98", false, "mail98@mail.com", "Prénom P:98", "Female", "Nom P:98", "98", false, 17 },
                    { 99, "Liège 99", "99", false, "mail99@mail.com", "Prénom P:99", "Male", "Nom P:99", "99", false, 17 },
                    { 100, "Liège 100", "100", false, "mail100@mail.com", "Prénom P:100", "Female", "Nom P:100", "100", false, 17 },
                    { 101, "Liège 101", "101", false, "mail101@mail.com", "Prénom P:101", "Male", "Nom P:101", "101", false, 17 },
                    { 102, "Liège 102", "102", false, "mail102@mail.com", "Prénom P:102", "Female", "Nom P:102", "102", false, 17 },
                    { 103, "Liège 103", "103", false, "mail103@mail.com", "Prénom P:103", "Male", "Nom P:103", "103", true, 18 },
                    { 104, "Liège 104", "104", false, "mail104@mail.com", "Prénom P:104", "Female", "Nom P:104", "104", true, 18 },
                    { 105, "Liège 105", "105", false, "mail105@mail.com", "Prénom P:105", "Male", "Nom P:105", "105", true, 18 },
                    { 106, "Liège 106", "106", false, "mail106@mail.com", "Prénom P:106", "Female", "Nom P:106", "106", true, 18 },
                    { 107, "Liège 107", "107", false, "mail107@mail.com", "Prénom P:107", "Male", "Nom P:107", "107", true, 18 },
                    { 108, "Liège 108", "108", false, "mail108@mail.com", "Prénom P:108", "Female", "Nom P:108", "108", true, 18 },
                    { 109, "Liège 109", "109", false, "mail109@mail.com", "Prénom P:109", "Male", "Nom P:109", "109", false, 19 },
                    { 110, "Liège 110", "110", false, "mail110@mail.com", "Prénom P:110", "Female", "Nom P:110", "110", false, 19 },
                    { 111, "Liège 111", "111", false, "mail111@mail.com", "Prénom P:111", "Male", "Nom P:111", "111", false, 19 },
                    { 112, "Liège 112", "112", false, "mail112@mail.com", "Prénom P:112", "Female", "Nom P:112", "112", false, 19 },
                    { 113, "Liège 113", "113", false, "mail113@mail.com", "Prénom P:113", "Male", "Nom P:113", "113", false, 19 },
                    { 114, "Liège 114", "114", false, "mail114@mail.com", "Prénom P:114", "Female", "Nom P:114", "114", false, 19 },
                    { 115, "Liège 115", "115", false, "mail115@mail.com", "Prénom P:115", "Male", "Nom P:115", "115", false, 20 },
                    { 116, "Liège 116", "116", false, "mail116@mail.com", "Prénom P:116", "Female", "Nom P:116", "116", false, 20 },
                    { 117, "Liège 117", "117", false, "mail117@mail.com", "Prénom P:117", "Male", "Nom P:117", "117", false, 20 },
                    { 118, "Liège 118", "118", false, "mail118@mail.com", "Prénom P:118", "Female", "Nom P:118", "118", false, 20 },
                    { 119, "Liège 119", "119", false, "mail119@mail.com", "Prénom P:119", "Male", "Nom P:119", "119", false, 20 },
                    { 120, "Liège 120", "120", false, "mail120@mail.com", "Prénom P:120", "Female", "Nom P:120", "120", false, 20 },
                    { 121, "Liège 121", "121", false, "mail121@mail.com", "Prénom P:121", "Male", "Nom P:121", "121", true, 21 },
                    { 122, "Liège 122", "122", false, "mail122@mail.com", "Prénom P:122", "Female", "Nom P:122", "122", true, 21 },
                    { 123, "Liège 123", "123", false, "mail123@mail.com", "Prénom P:123", "Male", "Nom P:123", "123", true, 21 },
                    { 124, "Liège 124", "124", false, "mail124@mail.com", "Prénom P:124", "Female", "Nom P:124", "124", true, 21 },
                    { 125, "Liège 125", "125", false, "mail125@mail.com", "Prénom P:125", "Male", "Nom P:125", "125", true, 21 },
                    { 126, "Liège 126", "126", false, "mail126@mail.com", "Prénom P:126", "Female", "Nom P:126", "126", true, 21 },
                    { 287, "Liège 287", "287", false, "mail287@mail.com", "Prénom L:287", "Male", "Nom L:287", "287", true, 48 },
                    { 288, "Liège 288", "288", false, "mail288@mail.com", "Prénom L:288", "Female", "Nom L:288", "288", true, 48 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Confrontations_TeamAId",
                table: "Confrontations",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_Confrontations_TeamBId",
                table: "Confrontations",
                column: "TeamBId");

            migrationBuilder.CreateIndex(
                name: "IX_Confrontations_TeamRefereeId",
                table: "Confrontations",
                column: "TeamRefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Confrontations_TerrainNumber",
                table: "Confrontations",
                column: "TerrainNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CategoryId",
                table: "Teams",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PoolId",
                table: "Teams",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Terrain_CategoryId",
                table: "Terrain",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Confrontations");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Terrain");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Pools");
        }
    }
}

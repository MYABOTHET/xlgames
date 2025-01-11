using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XlgamesBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Shared_GameServers = table.Column<string>(type: "text", nullable: false),
                    Shared_DedicatedServers = table.Column<string>(type: "text", nullable: false),
                    Shared_ServersWithoutGPU = table.Column<string>(type: "text", nullable: false),
                    Shared_ServersWithGPU = table.Column<string>(type: "text", nullable: false),
                    Shared_VPS = table.Column<string>(type: "text", nullable: false),
                    Shared_VPN = table.Column<string>(type: "text", nullable: false),
                    Shared_WebHosting = table.Column<string>(type: "text", nullable: false),
                    Shared_DataCenters = table.Column<string>(type: "text", nullable: false),
                    Shared_News = table.Column<string>(type: "text", nullable: false),
                    Shared_AboutUs = table.Column<string>(type: "text", nullable: false),
                    Shared_Contacts = table.Column<string>(type: "text", nullable: false),
                    Shared_TermsService = table.Column<string>(type: "text", nullable: false),
                    Shared_PrivacyPolicy = table.Column<string>(type: "text", nullable: false),
                    Shared_CookiePolicy = table.Column<string>(type: "text", nullable: false),
                    Shared_PersonalAccount = table.Column<string>(type: "text", nullable: false),
                    Shared_GameHosting = table.Column<string>(type: "text", nullable: false),
                    Shared_Discord = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Facebook = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Instagram = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Snapchat = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Twitter = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Vk = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Whatsapp = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Month = table.Column<string>(type: "text", nullable: false),
                    Shared_PriceFrom = table.Column<string>(type: "text", nullable: false),
                    Shared_CurrencySign = table.Column<string>(type: "text", nullable: false),
                    Shared_CurrencySignPosition = table.Column<bool>(type: "boolean", nullable: false),
                    Shared_Order = table.Column<string>(type: "text", nullable: false),
                    Shared_AnyCPU = table.Column<string>(type: "text", nullable: false),
                    Shared_AnyGPU = table.Column<string>(type: "text", nullable: false),
                    Shared_AnyCountry = table.Column<string>(type: "text", nullable: false),
                    Shared_AnyRegion = table.Column<string>(type: "text", nullable: false),
                    Shared_CPU = table.Column<string>(type: "text", nullable: false),
                    Shared_GPU = table.Column<string>(type: "text", nullable: false),
                    Shared_GHz = table.Column<string>(type: "text", nullable: false),
                    Shared_RAM = table.Column<string>(type: "text", nullable: false),
                    Shared_RAMType = table.Column<string>(type: "text", nullable: false),
                    Shared_Disk = table.Column<string>(type: "text", nullable: false),
                    Shared_DiskType = table.Column<string>(type: "text", nullable: false),
                    Shared_Country = table.Column<string>(type: "text", nullable: false),
                    Shared_Region = table.Column<string>(type: "text", nullable: false),
                    Shared_PricePerMonth = table.Column<string>(type: "text", nullable: false),
                    Shared_Cores = table.Column<string>(type: "text", nullable: false),
                    Shared_Slots = table.Column<string>(type: "text", nullable: false),
                    Shared_Control = table.Column<string>(type: "text", nullable: false),
                    Shared_AnySuggestionsStart = table.Column<string>(type: "text", nullable: false),
                    Shared_AnySuggestionsCenter = table.Column<string>(type: "text", nullable: false),
                    Shared_AnySuggestionsEnd = table.Column<string>(type: "text", nullable: false),
                    Shared_AnyQuestionsStart = table.Column<string>(type: "text", nullable: false),
                    Shared_AnyQuestionsCenter = table.Column<string>(type: "text", nullable: false),
                    Shared_AnyQuestionsEnd = table.Column<string>(type: "text", nullable: false),
                    Shared_Error = table.Column<string>(type: "text", nullable: false),
                    Shared_More = table.Column<string>(type: "text", nullable: false),
                    Shared_ReadMore = table.Column<string>(type: "text", nullable: false),
                    Shared_Head = table.Column<string>(type: "text", nullable: false),
                    Home_DataCentersDescription = table.Column<string>(type: "text", nullable: false),
                    Home_ServersWithoutGPU_Name = table.Column<string>(type: "text", nullable: false),
                    Home_ServersWithoutGPU_Description = table.Column<string>(type: "text", nullable: false),
                    Home_ServersWithGPU_Name = table.Column<string>(type: "text", nullable: false),
                    Home_ServersWithGPU_Description = table.Column<string>(type: "text", nullable: false),
                    Home_VPS_Name = table.Column<string>(type: "text", nullable: false),
                    Home_VPS_Description = table.Column<string>(type: "text", nullable: false),
                    Home_VPN_Name = table.Column<string>(type: "text", nullable: false),
                    Home_VPN_Description = table.Column<string>(type: "text", nullable: false),
                    Home_WebHosting_Name = table.Column<string>(type: "text", nullable: false),
                    Home_WebHosting_Description = table.Column<string>(type: "text", nullable: false),
                    Home_Head = table.Column<string>(type: "text", nullable: false),
                    Home_Title = table.Column<string>(type: "text", nullable: false),
                    GameServers_All = table.Column<string>(type: "text", nullable: false),
                    GameServers_Popular = table.Column<string>(type: "text", nullable: false),
                    GameServers_Search = table.Column<string>(type: "text", nullable: false),
                    GameServers_Head = table.Column<string>(type: "text", nullable: false),
                    GameServers_Title = table.Column<string>(type: "text", nullable: false),
                    GameServers_Name = table.Column<string>(type: "text", nullable: false),
                    WebHosting_Head = table.Column<string>(type: "text", nullable: false),
                    WebHosting_Title = table.Column<string>(type: "text", nullable: false),
                    WebHosting_Name = table.Column<string>(type: "text", nullable: false),
                    WebHosting_Description = table.Column<string>(type: "text", nullable: false),
                    DataCenters_DataCenterPoints = table.Column<string[]>(type: "text[]", nullable: false),
                    DataCenters_Head = table.Column<string>(type: "text", nullable: false),
                    DataCenters_Title = table.Column<string>(type: "text", nullable: false),
                    DataCenters_Name = table.Column<string>(type: "text", nullable: false),
                    DataCenters_Description = table.Column<string>(type: "text", nullable: false),
                    News_Head = table.Column<string>(type: "text", nullable: false),
                    News_Title = table.Column<string>(type: "text", nullable: false),
                    News_Name = table.Column<string>(type: "text", nullable: false),
                    AboutUs_Head = table.Column<string>(type: "text", nullable: false),
                    AboutUs_Title = table.Column<string>(type: "text", nullable: false),
                    AboutUs_Name = table.Column<string>(type: "text", nullable: false),
                    AboutUs_Description = table.Column<string>(type: "text", nullable: false),
                    TermsService_Head = table.Column<string>(type: "text", nullable: false),
                    TermsService_Title = table.Column<string>(type: "text", nullable: false),
                    TermsService_Name = table.Column<string>(type: "text", nullable: false),
                    TermsService_Description = table.Column<string>(type: "text", nullable: false),
                    PrivacyPolicy_Head = table.Column<string>(type: "text", nullable: false),
                    PrivacyPolicy_Title = table.Column<string>(type: "text", nullable: false),
                    PrivacyPolicy_Name = table.Column<string>(type: "text", nullable: false),
                    PrivacyPolicy_Description = table.Column<string>(type: "text", nullable: false),
                    GameServer_Head = table.Column<string>(type: "text", nullable: false),
                    GameServer_Title = table.Column<string>(type: "text", nullable: false),
                    VPS_Head = table.Column<string>(type: "text", nullable: false),
                    VPS_Title = table.Column<string>(type: "text", nullable: false),
                    VPS_Name = table.Column<string>(type: "text", nullable: false),
                    VPS_Description = table.Column<string>(type: "text", nullable: false),
                    VPN_Tariffs = table.Column<string>(type: "text", nullable: false),
                    VPN_Head = table.Column<string>(type: "text", nullable: false),
                    VPN_Title = table.Column<string>(type: "text", nullable: false),
                    VPN_Name = table.Column<string>(type: "text", nullable: false),
                    VPN_Description = table.Column<string>(type: "text", nullable: false),
                    ServersWithGPU_Head = table.Column<string>(type: "text", nullable: false),
                    ServersWithGPU_Title = table.Column<string>(type: "text", nullable: false),
                    ServersWithGPU_Name = table.Column<string>(type: "text", nullable: false),
                    ServersWithGPU_Description = table.Column<string>(type: "text", nullable: false),
                    ServersWithoutGPU_Head = table.Column<string>(type: "text", nullable: false),
                    ServersWithoutGPU_Title = table.Column<string>(type: "text", nullable: false),
                    ServersWithoutGPU_Name = table.Column<string>(type: "text", nullable: false),
                    ServersWithoutGPU_Description = table.Column<string>(type: "text", nullable: false),
                    Contacts_FullName = table.Column<string>(type: "text", nullable: false),
                    Contacts_PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Contacts_Email = table.Column<string>(type: "text", nullable: false),
                    Contacts_OGRNIP = table.Column<string>(type: "text", nullable: false),
                    Contacts_INN = table.Column<string>(type: "text", nullable: false),
                    Contacts_IP = table.Column<string>(type: "text", nullable: false),
                    Contacts_Head = table.Column<string>(type: "text", nullable: false),
                    Contacts_Title = table.Column<string>(type: "text", nullable: false),
                    Contacts_Name = table.Column<string>(type: "text", nullable: false),
                    Contacts_Description = table.Column<string>(type: "text", nullable: false),
                    CookiePolicy_CookiePolicyBanner_Name = table.Column<string>(type: "text", nullable: false),
                    CookiePolicy_CookiePolicyBanner_Description = table.Column<string>(type: "text", nullable: false),
                    CookiePolicy_Head = table.Column<string>(type: "text", nullable: false),
                    CookiePolicy_Title = table.Column<string>(type: "text", nullable: false),
                    CookiePolicy_Name = table.Column<string>(type: "text", nullable: false),
                    CookiePolicy_Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    WHMCSName = table.Column<string>(type: "text", nullable: false),
                    OriginalName = table.Column<string>(type: "text", nullable: false),
                    Locale = table.Column<string>(type: "text", nullable: false),
                    Lang = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logo = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Discord = table.Column<string>(type: "text", nullable: false),
                    Facebook = table.Column<string>(type: "text", nullable: false),
                    Instagram = table.Column<string>(type: "text", nullable: false),
                    Snapchat = table.Column<string>(type: "text", nullable: false),
                    Telegram = table.Column<string>(type: "text", nullable: false),
                    Twitter = table.Column<string>(type: "text", nullable: false),
                    Vk = table.Column<string>(type: "text", nullable: false),
                    Whatsapp = table.Column<string>(type: "text", nullable: false),
                    AboutUsSrc = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    OGRNIP = table.Column<string>(type: "text", nullable: false),
                    INN = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages_CookiePolicyCollection",
                columns: table => new
                {
                    CookiePolicyLanguageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages_CookiePolicyCollection", x => new { x.CookiePolicyLanguageId, x.Id });
                    table.ForeignKey(
                        name: "FK_Languages_CookiePolicyCollection_Languages_CookiePolicyLang~",
                        column: x => x.CookiePolicyLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages_DataCenterCollection",
                columns: table => new
                {
                    DataCentersLanguageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages_DataCenterCollection", x => new { x.DataCentersLanguageId, x.Id });
                    table.ForeignKey(
                        name: "FK_Languages_DataCenterCollection_Languages_DataCentersLanguag~",
                        column: x => x.DataCentersLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages_DataCenters",
                columns: table => new
                {
                    HomeLanguageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages_DataCenters", x => new { x.HomeLanguageId, x.Id });
                    table.ForeignKey(
                        name: "FK_Languages_DataCenters_Languages_HomeLanguageId",
                        column: x => x.HomeLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages_PrivacyPolicyCollection",
                columns: table => new
                {
                    PrivacyPolicyLanguageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages_PrivacyPolicyCollection", x => new { x.PrivacyPolicyLanguageId, x.Id });
                    table.ForeignKey(
                        name: "FK_Languages_PrivacyPolicyCollection_Languages_PrivacyPolicyLa~",
                        column: x => x.PrivacyPolicyLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages_TermsServiceCollection",
                columns: table => new
                {
                    TermsServiceLanguageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages_TermsServiceCollection", x => new { x.TermsServiceLanguageId, x.Id });
                    table.ForeignKey(
                        name: "FK_Languages_TermsServiceCollection_Languages_TermsServiceLang~",
                        column: x => x.TermsServiceLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages_VPNCollection",
                columns: table => new
                {
                    VPNLanguageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages_VPNCollection", x => new { x.VPNLanguageId, x.Id });
                    table.ForeignKey(
                        name: "FK_Languages_VPNCollection_Languages_VPNLanguageId",
                        column: x => x.VPNLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjectDatas",
                columns: new[] { "Id", "AboutUsSrc", "Discord", "Email", "Facebook", "INN", "Instagram", "Logo", "Name", "OGRNIP", "PhoneNumber", "Snapchat", "Telegram", "Twitter", "Vk", "Whatsapp", "Year" },
                values: new object[] { 1, "...", "...", "...", "...", "...", "...", "...", "...", "...", "...", "...", "...", "...", "...", "...", 2025 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 1, "ABOTHET", "$2a$11$EuWGvWkRsZYbmyfaP1HiWukPYs3HJ/0STq/CH/pz83./0FdXgAmA." });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name_WHMCSName_OriginalName_Locale",
                table: "Languages",
                columns: new[] { "Name", "WHMCSName", "OriginalName", "Locale" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages_CookiePolicyCollection");

            migrationBuilder.DropTable(
                name: "Languages_DataCenterCollection");

            migrationBuilder.DropTable(
                name: "Languages_DataCenters");

            migrationBuilder.DropTable(
                name: "Languages_PrivacyPolicyCollection");

            migrationBuilder.DropTable(
                name: "Languages_TermsServiceCollection");

            migrationBuilder.DropTable(
                name: "Languages_VPNCollection");

            migrationBuilder.DropTable(
                name: "ProjectDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}

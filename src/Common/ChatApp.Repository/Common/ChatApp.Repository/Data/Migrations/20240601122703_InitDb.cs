using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Repository.Common.ChatApp.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat_Chat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TotalMember = table.Column<int>(type: "int", nullable: false),
                    MaximumMember = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat_Chat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_RoleClaims_User_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "User_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat_GroupChatMember",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LeaveDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat_GroupChatMember", x => new { x.ChatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Chat_GroupChatMember_Chat_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat_Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_GroupChatMember_User_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat_Message",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsIncludeFile = table.Column<bool>(type: "bit", nullable: false),
                    _sendDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SendDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_Message_Chat_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat_Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_Message_User_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chat_WaitingMessageChat",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnReadMessageCount = table.Column<int>(type: "int", nullable: false),
                    NewMessageCount = table.Column<int>(type: "int", nullable: false),
                    LastRecievedMessage = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat_WaitingMessageChat", x => new { x.UserId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_Chat_WaitingMessageChat_Chat_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat_Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_WaitingMessageChat_User_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserClaims_User_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_User_UserLogins_User_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_User_UserRoles_User_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "User_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRoles_User_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_User_UserTokens_User_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat_MessageFile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BlobName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat_MessageFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_MessageFile_Chat_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Chat_Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Chat_Name",
                table: "Chat_Chat",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_GroupChatMember_ChatId",
                table: "Chat_GroupChatMember",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_GroupChatMember_UserId",
                table: "Chat_GroupChatMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Message_ChatId",
                table: "Chat_Message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Message_SenderId",
                table: "Chat_Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_MessageFile_MessageId",
                table: "Chat_MessageFile",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_WaitingMessageChat_ChatId",
                table: "Chat_WaitingMessageChat",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleClaims_RoleId",
                table: "User_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "User_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserClaims_UserId",
                table: "User_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserLogins_UserId",
                table: "User_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoles_RoleId",
                table: "User_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat_GroupChatMember");

            migrationBuilder.DropTable(
                name: "Chat_MessageFile");

            migrationBuilder.DropTable(
                name: "Chat_WaitingMessageChat");

            migrationBuilder.DropTable(
                name: "User_RoleClaims");

            migrationBuilder.DropTable(
                name: "User_UserClaims");

            migrationBuilder.DropTable(
                name: "User_UserLogins");

            migrationBuilder.DropTable(
                name: "User_UserRoles");

            migrationBuilder.DropTable(
                name: "User_UserTokens");

            migrationBuilder.DropTable(
                name: "Chat_Message");

            migrationBuilder.DropTable(
                name: "User_Roles");

            migrationBuilder.DropTable(
                name: "Chat_Chat");

            migrationBuilder.DropTable(
                name: "User_Users");
        }
    }
}

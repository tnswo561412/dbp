using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBPMessanger.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            // CREATE TABLE IF NOT EXISTS를 사용하여 이미 존재하는 테이블은 건너뛰기

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `department` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `name` longtext CHARACTER SET utf8mb4 NULL,
                    `parent_id` bigint NULL,
                    CONSTRAINT `pk_department` PRIMARY KEY (`id`),
                    KEY `ix_department_parent_id` (`parent_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `user` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `name` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `login_id` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `password` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `image` longblob NULL,
                    `zipcode` int NOT NULL,
                    `address` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `nickname` longtext CHARACTER SET utf8mb4 NULL,
                    `birthday` datetime(6) NULL,
                    `department_id` bigint NULL,
                    `role` longtext CHARACTER SET utf8mb4 NULL,
                    CONSTRAINT `pk_user` PRIMARY KEY (`id`),
                    KEY `ix_user_department_id` (`department_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `authoritychat` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `user_id` bigint NULL,
                    `target_user_id` bigint NULL,
                    `can_view` tinyint(1) NOT NULL,
                    CONSTRAINT `pk_authoritychat` PRIMARY KEY (`id`),
                    KEY `ix_authoritychat_target_user_id` (`target_user_id`),
                    KEY `ix_authoritychat_user_id` (`user_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `authoritydepartment` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `user_id` bigint NULL,
                    `target_user_id` bigint NULL,
                    `can_view` tinyint(1) NOT NULL,
                    CONSTRAINT `pk_authoritydepartment` PRIMARY KEY (`id`),
                    KEY `ix_authoritydepartment_target_user_id` (`target_user_id`),
                    KEY `ix_authoritydepartment_user_id` (`user_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `authorityuser` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `user_id` bigint NULL,
                    `target_user_id` bigint NULL,
                    `can_view` tinyint(1) NOT NULL,
                    CONSTRAINT `pk_authorityuser` PRIMARY KEY (`id`),
                    KEY `ix_authorityuser_target_user_id` (`target_user_id`),
                    KEY `ix_authorityuser_user_id` (`user_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `chatlog` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `sender_user_id` bigint NOT NULL,
                    `target_user_id` bigint NOT NULL,
                    `message` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `message_time` datetime(6) NOT NULL,
                    CONSTRAINT `pk_chatlog` PRIMARY KEY (`id`),
                    KEY `ix_chatlog_sender_user_id` (`sender_user_id`),
                    KEY `ix_chatlog_target_user_id` (`target_user_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `favorites` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `user_id` bigint NULL,
                    `target_user_id` bigint NULL,
                    `type` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `display_order` int NOT NULL,
                    CONSTRAINT `pk_favorites` PRIMARY KEY (`id`),
                    KEY `ix_favorites_target_user_id` (`target_user_id`),
                    KEY `ix_favorites_user_id` (`user_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `loginlog` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `user_id` bigint NULL,
                    `login_time` datetime(6) NULL,
                    `logout_time` datetime(6) NULL,
                    CONSTRAINT `pk_loginlog` PRIMARY KEY (`id`),
                    KEY `ix_loginlog_user_id` (`user_id`)
                ) CHARACTER SET=utf8mb4;
            ");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `multiprofile` (
                    `id` bigint NOT NULL AUTO_INCREMENT,
                    `user_id` bigint NULL,
                    `target_user_id` bigint NULL,
                    `image` longblob NULL,
                    CONSTRAINT `pk_multiprofile` PRIMARY KEY (`id`),
                    KEY `ix_multiprofile_target_user_id` (`target_user_id`),
                    KEY `ix_multiprofile_user_id` (`user_id`)
                ) CHARACTER SET=utf8mb4;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authoritychat");

            migrationBuilder.DropTable(
                name: "authoritydepartment");

            migrationBuilder.DropTable(
                name: "authorityuser");

            migrationBuilder.DropTable(
                name: "chatlog");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "loginlog");

            migrationBuilder.DropTable(
                name: "multiprofile");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}

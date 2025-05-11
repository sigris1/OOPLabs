using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Migrations;

[Migration(1, "Initial")]
public class InitialMigration : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        $"""

         create table users
         (
             user_id bigint primary key generated always as identity ,
             pin text not null ,
             balance bigint not null 
         );
         """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        $"""
         drop table users;
         """;
}
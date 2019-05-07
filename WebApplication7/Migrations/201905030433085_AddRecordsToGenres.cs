namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordsToGenres : DbMigration
    {
        public override void Up()
        {
            Sql("insert Genres(Name) values('John')");
            Sql("insert Genres(Name) values('Sam')");
            Sql("insert Genres(Name) values('Ben')");
            Sql("insert Genres(Name) values('Mahi')");
            Sql("insert Genres(Name) values('Virat')");
        }

        public override void Down()
        {
        }
    }
}

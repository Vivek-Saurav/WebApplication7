namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MembershipTypeName = c.String(),
                        Amount = c.Single(nullable: false),
                        DurationInMonth = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
        }
    }
}

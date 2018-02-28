namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_DEPARTMENT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_EMPLOYEE",
                c => new
                    {
                        EMPLOYEE_ID = c.Int(nullable: false, identity: true),
                        FIRST_NAME = c.String(nullable: false, maxLength: 20),
                        LAST_NAME = c.String(nullable: false, maxLength: 20),
                        SALARY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PERMANENT = c.Boolean(nullable: false),
                        DEPARTMENT_FK_ID = c.Int(),
                    })
                .PrimaryKey(t => t.EMPLOYEE_ID)
                .ForeignKey("dbo.TBL_DEPARTMENT", t => t.DEPARTMENT_FK_ID)
                .Index(t => t.DEPARTMENT_FK_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_EMPLOYEE", "DEPARTMENT_FK_ID", "dbo.TBL_DEPARTMENT");
            DropIndex("dbo.TBL_EMPLOYEE", new[] { "DEPARTMENT_FK_ID" });
            DropTable("dbo.TBL_EMPLOYEE");
            DropTable("dbo.TBL_DEPARTMENT");
        }
    }
}

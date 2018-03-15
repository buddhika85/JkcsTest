namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialEmployeeDataPopulation : DbMigration
    {
        public override void Up()
        {
            Sql("insert into TBL_EMPLOYEE (first_name, last_name, salary, permanent, department_fk_id) values ('John', 'James', 100000, 1, (select ID from TBL_DEPARTMENT where Name = 'Admin'))");
        }
        
        public override void Down()
        {
        }
    }
}

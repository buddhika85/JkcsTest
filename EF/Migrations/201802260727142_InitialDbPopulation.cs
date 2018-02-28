namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbPopulation : DbMigration
    {
        public override void Up()
        {
            Sql("insert into TBL_DEPARTMENT (name) values ('Admin')");
            Sql("insert into TBL_DEPARTMENT (name) values ('Sales')");
            Sql("insert into TBL_DEPARTMENT (name) values ('Production')");
            Sql("insert into TBL_DEPARTMENT (name) values ('IT')");
            Sql("insert into TBL_DEPARTMENT (name) values ('HR')");
            Sql("insert into TBL_DEPARTMENT (name) values ('Accounts')");

            //Sql("insert into TBL_EMPLOYEE (first_name, last_name, salary, permanent, department_fk_id) values ('John', 'James', 100000, 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}

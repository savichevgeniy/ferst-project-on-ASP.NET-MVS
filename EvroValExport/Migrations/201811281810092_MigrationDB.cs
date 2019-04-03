namespace EvroValExport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.WorkViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO_DataGroupField = c.String(),
                        FIO_DataTextField = c.String(),
                        FIO_DataValueField = c.String(),
                        StartTime_DataGroupField = c.String(),
                        StartTime_DataTextField = c.String(),
                        StartTime_DataValueField = c.String(),
                        EndTime_DataGroupField = c.String(),
                        EndTime_DataTextField = c.String(),
                        EndTime_DataValueField = c.String(),
                        CurrentTime_DataGroupField = c.String(),
                        CurrentTime_DataTextField = c.String(),
                        CurrentTime_DataValueField = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

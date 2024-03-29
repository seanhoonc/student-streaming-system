﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamTec.Migrations
{
    public partial class Creation : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Stream",
				columns: table => new
				{
					StreamID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Credits = table.Column<int>(type: "int", nullable: false),
					Day = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
					EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Capacity = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Stream", x => x.StreamID);
				});
            migrationBuilder.InsertData(
                table: "Stream",
                columns: new[] { "StreamID", "Room", "Credits", "Day", "StartTime", "EndTime", "Capacity" },
                values: new object[,] {
                 {"IT-5115-Com-A-03","T605","15","Monday","0800","1000","24"},
                 { "IT-5507-Lec-A-01","Zoom","15","Monday","0900","1000","21"},
                 { "IT-5119-Com-B-02","T604","15","Monday","0900","1100","25"},
                 { "IT-5501-Lec-A-01","Zoom","15","Monday","1000","1100","22"},
                 { "IT-5117-Lec-A-01","Zoom","15","Monday","1000","1200","20"},
                 { "IT-5504-Lec-A-01","Zoom","15","Monday","1100","1300","28"},
                 { "IT-6501-Lec-A-01","Zoom","15","Monday","1100","1300","23"},
                 { "IT-5119-Lec-A-01","Zoom","15","Monday","1200","1300","26"},
                 { "SD-6502-Lec-A-01","Zoom","15","Monday","1300","1400","24"},
                 { "IT-5115-Com-B-02","T602","15","Monday","1300","1500","27"},
                 { "IT-5116-Com-A-03","T601","15","Monday","1300","1500","27"},
                 { "IT-5118-Com-A-01","T604","15","Monday","1300","1500","20"},
                 { "IT-5120-Lec-A-01","Zoom","15","Monday","1300","1500","21"},
                 { "IT-7502-Tut-A-02","Zoom","15","Monday","1300","1500","24"},
                 { "SD-6502-Com-A-01","Zoom","15","Monday","1400","1700","0"},
                 { "IT-5501-Lec-B-01","Zoom","15","Tuesday","0800","0900","27"},
                 { "IT-5115-Lec-A-01","Zoom","15","Tuesday","0900","1000","26"},
                 { "IT-7510-Lec-B-01","Zoom","15","Tuesday","0900","1000","26"},
                 { "IT-5501-Tut-A-01","Zoom","15","Tuesday","0900","1100","22"},
                 { "IT-5120-Com-A-01","T603","15","Tuesday","0900","1200","25"},
                 { "SD-6501-Com-A-01","Zoom","15","Tuesday","0900","1200","21"},
                 { "SD-6502-Com-B-01","Zoom","15","Tuesday","0900","1200","30"},
                 { "NI-6503-Lec-A-01","Zoom","15","Tuesday","1000","1100","25"},
                 { "IT-5116-Com-B-02","T602","15","Tuesday","1000","1200","22"},
                 { "IT-5118-Com-A-03","T306","15","Tuesday","1000","1200","29"},
                 { "IT-5119-Com-A-02","T604","15","Tuesday","1000","1200","26"},
                 { "NI-7501-Com-A-01","Zoom","15","Tuesday","1000","1200","25"},
                 { "IT-5506-Lec-A-01","Zoom","15","Tuesday","1100","1200","30"},
                 { "IT-5115-Com-B-01","T607","15","Tuesday","1100","1300","26"},
                 { "IT-5501-Tut-A-02","Zoom","15","Tuesday","1200","1400","29"},
                 { "IT-5116-Lec-A-01","Zoom","15","Tuesday","1300","1400","27"},
                 { "IT-5119-Com-B-01","T601","15","Tuesday","1300","1500","29"},
                 { "IT-5506-Com-A-01","T607","15","Tuesday","1300","1500","20"},
                 { "IT-7502-Tut-A-01","Zoom","15","Tuesday","1300","1500","23"},
                 { "IT-5120-Com-A-02","T603","15","Tuesday","1300","1600","25"},
                 { "NI-6501-Com-A-01","Zoom","15","Tuesday","1400","1700","23"},
                 { "IT-5118-Lec-A-01","Zoom","15","Tuesday","1500","1600","20"},
                 { "IT-5507-Com-A-02","T604","15","Tuesday","1500","1700","28"},
                 { "IT-6502-Lec-A-01","Zoom","15","Wednesday","0800","1000","28"},
                 { "IT-5122-Lec-A-01","Zoom","15","Wednesday","0900","1000","26"},
                 { "NI-6501-Lec-A-01","Zoom","15","Wednesday","0900","1000","25"},
                 { "IT-5115-Com-A-02","T604","15","Wednesday","0900","1100","26"},
                 { "IT-5507-Com-B-03","T605","15","Wednesday","0900","1100","25"},
                 { "IT-5117-Com-A-01","T603","15","Wednesday","0900","1200","26"},
                 { "SD-7501-Lec-A-01","Zoom","15","Wednesday","1000","1100","28"},
                 { "IT-5122-Com-B-01","T608","15","Wednesday","1000","1200","28"},
                 { "IT-6501-Com-A-02","Zoom","15","Wednesday","1000","1200","20"},
                 { "IT-5116-Com-A-02","T606","15","Wednesday","1100","1300","26"},
                 { "IT-5121-Com-A-02","T605","15","Wednesday","1100","1400","24"},
                 { "IT-5506-Com-B-01","T608","15","Wednesday","1200","1400","29"},
                 { "IT-5115-Com-A-01","T602","15","Wednesday","1300","1500","22"},
                 { "IT-5117-Com-A-03","T603","15","Wednesday","1300","1600","24"},
                 { "SD-7501-Com-A-01","Zoom","15","Wednesday","1300","1600","30"},
                 { "IT-5118-Com-B-02","C103","15","Wednesday","1400","1600","26"},
                 { "IT-5507-Com-A-03","T605","15","Wednesday","1400","1600","25"},
                 { "IT-5501-Tut-B-01","Zoom","15","Wednesday","1500","1700","21"},
                 { "IT-5506-Com-A-02","T608","15","Wednesday","1500","1700","29"},
                 { "IT-5504-Com-A-02","T605","15","Thursday","0800","1100","28"},
                 { "IT-5115-Com-B-03","T608","15","Thursday","0900","1100","21"},
                 { "IT-5118-Com-B-01","T306","15","Thursday","0900","1100","23"},
                 { "IT-5507-Com-A-01","T601","15","Thursday","0900","1100","22"},
                 { "IT-6501-Com-A-01","Zoom","15","Thursday","0900","1100","28"},
                 { "IT-5116-Com-A-01","T606","15","Thursday","1100","1300","28"},
                 { "IT-5122-Com-A-01","T608","15","Thursday","1100","1300","20"},
                 { "NI-7501-Com-B-01","Zoom","15","Thursday","1100","1300","25"},
                 { "IT-7510-Tut-A-01","Zoom","15","Thursday","1200","1300","21"},
                 { "IT-5501-Tut-B-02","Zoom","15","Thursday","1200","1400","28"},
                 { "SD-6501-Lec-A-01","Zoom","15","Thursday","1300","1400","26"},
                 { "IT-5118-Com-B-03","T304","15","Thursday","1300","1500","21"},
                 { "IT-5122-Com-B-02","T608","15","Thursday","1300","1500","21"},
                 { "IT-5117-Com-A-02","T603","15","Thursday","1300","1600","21"},
                 { "IT-5119-Com-A-01","T604","15","Thursday","1400","1600","21"},
                 { "IT-6501-Com-A-03","Zoom","15","Thursday","1400","1600","25"},
                 { "IT-5506-Com-B-02","T608","15","Thursday","1500","1700","26"},
                 { "IT-5121-Lec-A-01","Zoom","15","Friday","0900","1100","28"},
                 { "IT-6502-Com-A-01","Zoom","15","Friday","0900","1100","24"},
                 { "IT-5504-Com-A-01","T603","15","Friday","0900","1200","21"},
                 { "IT-5116-Com-B-01","T602","15","Friday","1000","1200","30"},
                 { "IT-5122-Com-A-02","T608","15","Friday","1200","1400","23"},
                 { "IT-5507-Com-B-02","T602","15","Friday","1200","1400","27"},
                 { "IT-5121-Com-A-01","T601","15","Friday","1200","1500","25"},
                 { "NI-6503-Com-A-01","Zoom","15","Friday","1200","1500","21"},
                 { "SD-6501-Com-A-02","Zoom","15","Friday","1300","1600","27"},
                 { "IT-5116-Com-B-03","T606","15","Friday","1400","1600","25"},
                 { "IT-5118-Com-A-02","T604","15","Friday","1400","1600","29"},
                 { "IT-5507-Com-B-01","T608","15","Friday","1400","1600","28"},
                 { "IT-7510-Lec-A-01","Zoom","15","Tuesday","1500","1600","27"},
                 { "CS-6502-Lec-A-01","Zoom","15","Monday","0800","1000","23"},
                 { "IT-4107-Lec-A-01","Zoom","15","Monday","0900","1000","29"},
                 { "IT-4107-Com-A-01","T601","15","Monday","1100","1300","29"},
                 { "IT-4107-Com-A-02","T604","15","Monday","1100","1300","30"},
                 { "CS-7503-Lec-A-01","Zoom","15","Monday","1400","1500","25"},
                 { "IT-4106-Com-B-02","T606","15","Monday","1400","1600","28"},
                 { "CS-7501-Lec-A-01","Zoom","15","Monday","1500","1600","21"},
                 { "IT-4106-Lec-A-01","Zoom","15","Tuesday","1000","1100","27"},
                 { "CS-7501-Com-A-01","Zoom","15","Tuesday","1000","1300","23"},
                 { "CS-7504-Lec-A-01","Zoom","15","Tuesday","1200","1300","27"},
                 { "CS-6502-Com-A-02","Zoom","15","Tuesday","1200","1400","24"},
                 { "IT-4106-Com-A-02","T605","15","Tuesday","1200","1400","27"},
                 { "IT-4107-Com-B-01","T604","15","Tuesday","1200","1400","27"},
                 { "IT-4105-Lec-A-01","Zoom","15","Tuesday","1500","1600","23"},
                 { "IT-4105-Com-A-01","T601","15","Wednesday","0900","1100","24"},
                 { "CS-6502-Com-A-01","Zoom","15","Wednesday","1000","1200","20"},
                 { "CS-7505-Lec-A-01","Zoom","15","Wednesday","1200","1300","27"},
                 { "IT-4104-Lec-A-01","Zoom","15","Wednesday","1200","1300","24"},
                 { "DS-6504-Com-A-01","Zoom","15","Wednesday","1200","1400","23"},
                 { "IT-4106-Com-A-01","T604","15","Wednesday","1300","1500","28"},
                 { "IT-4107-Com-B-02","T601","15","Wednesday","1300","1500","28"},
                 { "CS-7503-Com-A-01","Zoom","15","Wednesday","1400","1700","28"},
                 { "CS-7504-Com-A-01","Zoom","15","Thursday","0800","1100","30"},
                 { "CS-6501-Com-A-02","Zoom","15","Thursday","0900","1100","20"},
                 { "IT-4104-Com-A-01","T603","15","Thursday","0900","1100","22"},
                 { "IT-4105-Com-A-02","T607","15","Thursday","0900","1100","23"},
                 { "IT-4104-Com-A-02","T604","15","Thursday","1200","1400","20"},
                 { "IT-4105-Com-B-01","T602","15","Thursday","1200","1400","26"},
                 { "CS-7505-Com-A-01","Zoom","15","Thursday","1300","1600","28"},
                 { "DS-6504-Com-B-01","Zoom","15","Thursday","1400","1600","28"},
                 { "IT-4104-Com-B-01","T605","15","Thursday","1400","1600","26"},
                 { "CS-6501-Lec-A-01","Zoom","15","Friday","0900","1100","23"},
                 { "IT-4104-Com-B-02","T607","15","Friday","0900","1100","29"},
                 { "IT-4106-Com-B-01","T601","15","Friday","0900","1100","29"},
                 { "CS-7504-Com-A-02","Zoom","15","Friday","0900","1200","22"},
                 { "IT-4105-Com-B-02","T604","15","Friday","1200","1400","30"},
                 { "CS-6501-Com-A-01","Zoom","15","Friday","1200","1400","29"},
                 { "CS-7501-Com-A-02","Zoom","15","Friday","1400","1700","29"}
        });

            migrationBuilder.CreateTable(
				name: "Student",
				columns: table => new
				{
					StudentId = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Student", x => x.StudentId);
				});
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Email" },
                values: new object[,] {
                {"2022091", "admin@streamtec.com" } 
                });

            migrationBuilder.CreateTable(
				name: "Enrollment",
				columns: table => new
				{
					EnrollmentID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					StudentId = table.Column<string>(type: "nvarchar(7)", nullable: false),
					StreamID = table.Column<string>(type: "nvarchar(50)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
					table.ForeignKey(
						name: "FK_Enrollment_Stream_StreamID",
						column: x => x.StreamID,
						principalTable: "Stream",
						principalColumn: "StreamID",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Enrollment_Student_StudentId",
						column: x => x.StudentId,
						principalTable: "Student",
						principalColumn: "StudentId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Enrollment_StreamID",
				table: "Enrollment",
				column: "StreamID");

			migrationBuilder.CreateIndex(
				name: "IX_Enrollment_StudentId",
				table: "Enrollment",
				column: "StudentId");			
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Stream");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}

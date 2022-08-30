﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamTec.Migrations
{
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Stream",
                columns: new[] { "StreamID", "Room", "Credits", "Day", "StartTime", "EndTime", "Capacity" },
                values: new object[,] {
				{"IT-5115-Com-A-03","T605","15","Monday","08:00","10:00","24"},
			 	{"IT-5507-Lec-A-01","Zoom","15","Monday","09:00","10:00","21"},
			 	{"IT-5119-Com-B-02","T604","15","Monday","09:00","11:00","25"},
			 	{"IT-5501-Lec-A-01","Zoom","15","Monday","10:00","11:00","22"},
			 	{"IT-5117-Lec-A-01","Zoom","15","Monday","10:00","12:00","20"},
			 	{"IT-5504-Lec-A-01","Zoom","15","Monday","11:00","13:00","28"},
			 	{"IT-6501-Lec-A-01","Zoom","15","Monday","11:00","13:00","23"},
			 	{"IT-5119-Lec-A-01","Zoom","15","Monday","12:00","13:00","26"},
			 	{"SD-6502-Lec-A-01","Zoom","15","Monday","13:00","14:00","24"},
			 	{"IT-5115-Com-B-02","T602","15","Monday","13:00","15:00","27"},
			 	{"IT-5116-Com-A-03","T601","15","Monday","13:00","15:00","27"},
			 	{"IT-5118-Com-A-01","T604","15","Monday","13:00","15:00","20"},
			 	{"IT-5120-Lec-A-01","Zoom","15","Monday","13:00","15:00","21"},
			 	{"IT-7502-Tut-A-02","Zoom","15","Monday","13:00","15:00","24"},
			 	{"SD-6502-Com-A-01","Zoom","15","Monday","14:00","17:00","24"},
			 	{"IT-5501-Lec-B-01","Zoom","15","Tuesday","08:00","09:00","27"},
			 	{"IT-5115-Lec-A-01","Zoom","15","Tuesday","09:00","10:00","26"},
			 	{"IT-7510-Lec-B-01","Zoom","15","Tuesday","09:00","10:00","26"},
			 	{"IT-5501-Tut-A-01","Zoom","15","Tuesday","09:00","11:00","22"},
			 	{"IT-5120-Com-A-01","T603","15","Tuesday","09:00","12:00","25"},
			 	{"SD-6501-Com-A-01","Zoom","15","Tuesday","09:00","12:00","21"},
			 	{"SD-6502-Com-B-01","Zoom","15","Tuesday","09:00","12:00","30"},
			 	{"NI-6503-Lec-A-01","Zoom","15","Tuesday","10:00","11:00","25"},
			 	{"IT-5116-Com-B-02","T602","15","Tuesday","10:00","12:00","22"},
			 	{"IT-5118-Com-A-03","T306","15","Tuesday","10:00","12:00","29"},
			 	{"IT-5119-Com-A-02","T604","15","Tuesday","10:00","12:00","26"},
			 	{"NI-7501-Com-A-01","Zoom","15","Tuesday","10:00","12:00","25"},
			 	{"IT-5506-Lec-A-01","Zoom","15","Tuesday","11:00","12:00","30"},
			 	{"IT-5115-Com-B-01","T607","15","Tuesday","11:00","13:00","26"},
			 	{"IT-5501-Tut-A-02","Zoom","15","Tuesday","12:00","14:00","29"},
			 	{"IT-5116-Lec-A-01","Zoom","15","Tuesday","13:00","14:00","27"},
			 	{"IT-5119-Com-B-01","T601","15","Tuesday","13:00","15:00","29"},
			 	{"IT-5506-Com-A-01","T607","15","Tuesday","13:00","15:00","20"},
			 	{"IT-7502-Tut-A-01","Zoom","15","Tuesday","13:00","15:00","23"},
			 	{"IT-5120-Com-A-02","T603","15","Tuesday","13:00","16:00","25"},
			 	{"NI-6501-Com-A-01","Zoom","15","Tuesday","14:00","17:00","23"},
			 	{"IT-5118-Lec-A-01","Zoom","15","Tuesday","15:00","16:00","20"},
			 	{"IT-5507-Com-A-02","T604","15","Tuesday","15:00","17:00","28"},
			 	{"IT-6502-Lec-A-01","Zoom","15","Wednesday","08:00","10:00","28"},
			 	{"IT-5122-Lec-A-01","Zoom","15","Wednesday","09:00","10:00","26"},
			 	{"NI-6501-Lec-A-01","Zoom","15","Wednesday","09:00","10:00","25"},
			 	{"IT-5115-Com-A-02","T604","15","Wednesday","09:00","11:00","26"},
			 	{"IT-5507-Com-B-03","T605","15","Wednesday","09:00","11:00","25"},
			 	{"IT-5117-Com-A-01","T603","15","Wednesday","09:00","12:00","26"},
			 	{"SD-7501-Lec-A-01","Zoom","15","Wednesday","10:00","11:00","28"},
			 	{"IT-5122-Com-B-01","T608","15","Wednesday","10:00","12:00","28"},
			 	{"IT-6501-Com-A-02","Zoom","15","Wednesday","10:00","12:00","20"},
			 	{"IT-5116-Com-A-02","T606","15","Wednesday","11:00","13:00","26"},
			 	{"IT-5121-Com-A-02","T605","15","Wednesday","11:00","14:00","24"},
			 	{"IT-5506-Com-B-01","T608","15","Wednesday","12:00","14:00","29"},
			 	{"IT-5115-Com-A-01","T602","15","Wednesday","13:00","15:00","22"},
			 	{"IT-5117-Com-A-03","T603","15","Wednesday","13:00","16:00","24"},
			 	{"SD-7501-Com-A-01","Zoom","15","Wednesday","13:00","16:00","30"},
			 	{"IT-5118-Com-B-02","C103","15","Wednesday","14:00","16:00","26"},
			 	{"IT-5507-Com-A-03","T605","15","Wednesday","14:00","16:00","25"},
			 	{"IT-5501-Tut-B-01","Zoom","15","Wednesday","15:00","17:00","21"},
			 	{"IT-5506-Com-A-02","T608","15","Wednesday","15:00","17:00","29"},
			 	{"IT-5504-Com-A-02","T605","15","Thursday","08:00","11:00","28"},
			 	{"IT-5115-Com-B-03","T608","15","Thursday","09:00","11:00","21"},
			 	{"IT-5118-Com-B-01","T306","15","Thursday","09:00","11:00","23"},
			 	{"IT-5507-Com-A-01","T601","15","Thursday","09:00","11:00","22"},
			 	{"IT-6501-Com-A-01","Zoom","15","Thursday","09:00","11:00","28"},
			 	{"IT-5116-Com-A-01","T606","15","Thursday","11:00","13:00","28"},
			 	{"IT-5122-Com-A-01","T608","15","Thursday","11:00","13:00","20"},
			 	{"NI-7501-Com-B-01","Zoom","15","Thursday","11:00","13:00","25"},
			 	{"IT-7510-Tut-A-01","Zoom","15","Thursday","12:00","13:00","21"},
			 	{"IT-5501-Tut-B-02","Zoom","15","Thursday","12:00","14:00","28"},
			 	{"SD-6501-Lec-A-01","Zoom","15","Thursday","13:00","14:00","26"},
			 	{"IT-5118-Com-B-03","T304","15","Thursday","13:00","15:00","21"},
			 	{"IT-5122-Com-B-02","T608","15","Thursday","13:00","15:00","21"},
			 	{"IT-5117-Com-A-02","T603","15","Thursday","13:00","16:00","21"},
			 	{"IT-5119-Com-A-01","T604","15","Thursday","14:00","16:00","21"},
			 	{"IT-6501-Com-A-03","Zoom","15","Thursday","14:00","16:00","25"},
			 	{"IT-5506-Com-B-02","T608","15","Thursday","15:00","17:00","26"},
			 	{"IT-5121-Lec-A-01","Zoom","15","Friday","09:00","11:00","28"},
			 	{"IT-6502-Com-A-01","Zoom","15","Friday","09:00","11:00","24"},
			 	{"IT-5504-Com-A-01","T603","15","Friday","09:00","12:00","21"},
			 	{"IT-5116-Com-B-01","T602","15","Friday","10:00","12:00","30"},
			 	{"IT-5122-Com-A-02","T608","15","Friday","12:00","14:00","23"},
			 	{"IT-5507-Com-B-02","T602","15","Friday","12:00","14:00","27"},
			 	{"IT-5121-Com-A-01","T601","15","Friday","12:00","15:00","25"},
			 	{"NI-6503-Com-A-01","Zoom","15","Friday","12:00","15:00","21"},
			 	{"SD-6501-Com-A-02","Zoom","15","Friday","13:00","16:00","27"},
			 	{"IT-5116-Com-B-03","T606","15","Friday","14:00","16:00","25"},
			 	{"IT-5118-Com-A-02","T604","15","Friday","14:00","16:00","29"},
			 	{"IT-5507-Com-B-01","T608","15","Friday","14:00","16:00","28"},
			 	{"IT-7510-Lec-A-01","Zoom","15","Tuesday","15:00","16:00","27"},
			 	{"CS-6502-Lec-A-01","Zoom","15","Monday","08:00","10:00","23"},
			 	{"IT-4107-Lec-A-01","Zoom","15","Monday","09:00","10:00","29"},
			 	{"IT-4107-Com-A-01","T601","15","Monday","11:00","13:00","29"},
			 	{"IT-4107-Com-A-02","T604","15","Monday","11:00","13:00","30"},
			 	{"CS-7503-Lec-A-01","Zoom","15","Monday","14:00","15:00","25"},
			 	{"IT-4106-Com-B-02","T606","15","Monday","14:00","16:00","28"},
			 	{"CS-7501-Lec-A-01","Zoom","15","Monday","15:00","16:00","21"},
			 	{"IT-4106-Lec-A-01","Zoom","15","Tuesday","10:00","11:00","27"},
			 	{"CS-7501-Com-A-01","Zoom","15","Tuesday","10:00","13:00","23"},
			 	{"CS-7504-Lec-A-01","Zoom","15","Tuesday","12:00","13:00","27"},
			 	{"CS-6502-Com-A-02","Zoom","15","Tuesday","12:00","14:00","24"},
			 	{"IT-4106-Com-A-02","T605","15","Tuesday","12:00","14:00","27"},
			 	{"IT-4107-Com-B-01","T604","15","Tuesday","12:00","14:00","27"},
			 	{"IT-4105-Lec-A-01","Zoom","15","Tuesday","15:00","16:00","23"},
			 	{"IT-4105-Com-A-01","T601","15","Wednesday","09:00","11:00","24"},
			 	{"CS-6502-Com-A-01","Zoom","15","Wednesday","10:00","12:00","20"},
			 	{"CS-7505-Lec-A-01","Zoom","15","Wednesday","12:00","13:00","27"},
			 	{"IT-4104-Lec-A-01","Zoom","15","Wednesday","12:00","13:00","24"},
			 	{"DS-6504-Com-A-01","Zoom","15","Wednesday","12:00","14:00","23"},
			 	{"IT-4106-Com-A-01","T604","15","Wednesday","13:00","15:00","28"},
			 	{"IT-4107-Com-B-02","T601","15","Wednesday","13:00","15:00","28"},
			 	{"CS-7503-Com-A-01","Zoom","15","Wednesday","14:00","17:00","28"},
			 	{"CS-7504-Com-A-01","Zoom","15","Thursday","08:00","11:00","30"},
			 	{"CS-6501-Com-A-02","Zoom","15","Thursday","09:00","11:00","20"},
			 	{"IT-4104-Com-A-01","T603","15","Thursday","09:00","11:00","22"},
			 	{"IT-4105-Com-A-02","T607","15","Thursday","09:00","11:00","23"},
			 	{"IT-4104-Com-A-02","T604","15","Thursday","12:00","14:00","20"},
			 	{"IT-4105-Com-B-01","T602","15","Thursday","12:00","14:00","26"},
			 	{"CS-7505-Com-A-01","Zoom","15","Thursday","13:00","16:00","28"},
			 	{"DS-6504-Com-B-01","Zoom","15","Thursday","14:00","16:00","28"},
			 	{"IT-4104-Com-B-01","T605","15","Thursday","14:00","16:00","26"},
			 	{"CS-6501-Lec-A-01","Zoom","15","Friday","09:00","11:00","23"},
			 	{"IT-4104-Com-B-02","T607","15","Friday","09:00","11:00","29"},
			 	{"IT-4106-Com-B-01","T601","15","Friday","09:00","11:00","29"},
			 	{"CS-7504-Com-A-02","Zoom","15","Friday","09:00","12:00","22"},
			 	{"IT-4105-Com-B-02","T604","15","Friday","12:00","14:00","30"},
			 	{"CS-6501-Com-A-01","Zoom","15","Friday","12:00","14:00","29"},
			 	{"CS-7501-Com-A-02","Zoom","15","Friday","14:00","17:00","29"}
				 });
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Email" },
                values: new object[,]
                {
                 {"2208827","justin.martin01@student.weltec.ac.nz"},
                 {"2208266","ethan.riwaka01@student.weltec.ac.nz"},
                 {"2208282","sunghoon.cho@student.weltec.ac.nz"},
                 {"2107212","jeremy2001@gmail.com"},
                 {"2307542","darolmansfield@outlook.com"},
                 {"2007872","rebeccasmith01@hotmail.com"},
                 {"2209341","lily2008@gmail.com"},
                 {"2106785","abel.abraham01@student.weltec.ac.nz"},
                 {"2309174","susan.solomons01@student.weltec.ac.nz"}

                });
            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "EnrollmentID", "StudentId", "StreamID" },
                values: new object[,]
                {
                {"1","2208827","DS-6504-Com-B-01"},
                {"2","2208827","DS-6504-Com-A-01"},
                {"3","2208827","CS-7501-Com-A-02"},
                {"4","2208266","DS-6504-Com-B-01"},
                {"5","2208266","DS-6504-Com-A-01"},
                {"6","2208266","CS-7501-Com-A-02"}
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
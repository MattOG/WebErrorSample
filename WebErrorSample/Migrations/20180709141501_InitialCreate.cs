using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebErrorSample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentEntityId);
                });

            migrationBuilder.CreateTable(
                name: "ToyCategories",
                columns: table => new
                {
                    ToyCategoryEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyCategories", x => x.ToyCategoryEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentEntityId = table.Column<int>(nullable: false),
                    ChildName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildEntityId);
                    table.ForeignKey(
                        name: "FK_Children_Parents_ParentEntityId",
                        column: x => x.ParentEntityId,
                        principalTable: "Parents",
                        principalColumn: "ParentEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    ToyEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildEntityId = table.Column<int>(nullable: false),
                    ToyCategoryEntityId = table.Column<int>(nullable: false),
                    ToyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.ToyEntityId);
                    table.ForeignKey(
                        name: "FK_Toys_Children_ChildEntityId",
                        column: x => x.ChildEntityId,
                        principalTable: "Children",
                        principalColumn: "ChildEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Toys_ToyCategories_ToyCategoryEntityId",
                        column: x => x.ToyCategoryEntityId,
                        principalTable: "ToyCategories",
                        principalColumn: "ToyCategoryEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentEntityId", "ParentName" },
                values: new object[,]
                {
                    { 1, "Parent 1" },
                    { 2, "Parent 2" },
                    { 3, "Parent 3" },
                    { 4, "Parent 4" },
                    { 5, "Parent 5" }
                });

            migrationBuilder.InsertData(
                table: "ToyCategories",
                columns: new[] { "ToyCategoryEntityId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" },
                    { 3, "Category 3" },
                    { 4, "Category 4" },
                    { 5, "Category 5" }
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "ChildEntityId", "ChildName", "ParentEntityId" },
                values: new object[,]
                {
                    { 1, "Child 1", 1 },
                    { 23, "Child 23", 5 },
                    { 22, "Child 22", 5 },
                    { 21, "Child 21", 5 },
                    { 20, "Child 20", 4 },
                    { 19, "Child 19", 4 },
                    { 18, "Child 18", 4 },
                    { 17, "Child 17", 4 },
                    { 16, "Child 16", 4 },
                    { 15, "Child 15", 3 },
                    { 14, "Child 14", 3 },
                    { 24, "Child 24", 5 },
                    { 13, "Child 13", 3 },
                    { 11, "Child 11", 3 },
                    { 10, "Child 10", 2 },
                    { 9, "Child 9", 2 },
                    { 8, "Child 8", 2 },
                    { 7, "Child 7", 2 },
                    { 6, "Child 6", 2 },
                    { 5, "Child 5", 1 },
                    { 4, "Child 4", 1 },
                    { 3, "Child 3", 1 },
                    { 2, "Child 2", 1 },
                    { 12, "Child 12", 3 },
                    { 25, "Child 25", 5 }
                });

            migrationBuilder.InsertData(
                table: "Toys",
                columns: new[] { "ToyEntityId", "ChildEntityId", "ToyCategoryEntityId", "ToyName" },
                values: new object[,]
                {
                    { 1, 1, 1, "Toy 1" },
                    { 23, 23, 3, "Toy 23" },
                    { 22, 22, 2, "Toy 22" },
                    { 21, 21, 1, "Toy 21" },
                    { 20, 20, 5, "Toy 20" },
                    { 19, 19, 4, "Toy 19" },
                    { 18, 18, 3, "Toy 18" },
                    { 17, 17, 2, "Toy 17" },
                    { 16, 16, 1, "Toy 16" },
                    { 15, 15, 5, "Toy 15" },
                    { 14, 14, 4, "Toy 14" },
                    { 24, 24, 4, "Toy 24" },
                    { 13, 13, 3, "Toy 13" },
                    { 11, 11, 1, "Toy 11" },
                    { 10, 10, 5, "Toy 10" },
                    { 9, 9, 4, "Toy 9" },
                    { 8, 8, 3, "Toy 8" },
                    { 7, 7, 2, "Toy 7" },
                    { 6, 6, 1, "Toy 6" },
                    { 5, 5, 5, "Toy 5" },
                    { 4, 4, 4, "Toy 4" },
                    { 3, 3, 3, "Toy 3" },
                    { 2, 2, 2, "Toy 2" },
                    { 12, 12, 2, "Toy 12" },
                    { 25, 25, 5, "Toy 25" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentEntityId",
                table: "Children",
                column: "ParentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Toys_ChildEntityId",
                table: "Toys",
                column: "ChildEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toys_ToyCategoryEntityId",
                table: "Toys",
                column: "ToyCategoryEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "ToyCategories");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}

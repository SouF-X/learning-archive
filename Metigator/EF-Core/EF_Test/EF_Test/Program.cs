using EF_Test;
using EF_Test.Models;

using var db = new AppDbContext();

/*var department = new Department()
{
    Name = "Soufiane"
};

db.Departments.Add(department);
db.SaveChanges();*/

var department = db.Departments.Find(1);

if (department != null)
{
/*    department.Name = "Class 1";
    db.SaveChanges();*/

    db.Departments.Remove(department);
    db.SaveChanges();
}

    Console.WriteLine("Inserting a new department");


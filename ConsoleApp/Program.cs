using ConsoleApp.DAL;

var _contex = new BookAppDbContext();
var category= _contex.Categories.Where(c=> c.CategoryId==3).SingleOrDefault();
_contex.Categories.Remove(category);
_contex.SaveChanges();

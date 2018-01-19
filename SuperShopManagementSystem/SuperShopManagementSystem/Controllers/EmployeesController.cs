using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
            EmployeeBLL employeeBll = new EmployeeBLL();
            DropDownList dropDown = new DropDownList();
            Common common = new Common();
            bool status = false;

        //GET: Create Employee 
        public ActionResult Create()
        {
            ViewBag.ReferenceId = dropDown.GetAllEmployee();
            ViewBag.OutletId= dropDown.GetAllOutlet();
            return View();
        }


        //POST: Create Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please Upload an Image");
            }

            if (ImageFile != null)
            {
                bool isValidFormat = common.CheckImageFormat(ImageFile);
                if (isValidFormat == false)
                {
                    ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
                }
                else
                {
                    byte[] convertedImage = common.ConvertImage(ImageFile);
                    employee.Image = convertedImage;
                }


            }
            employee.IsDeleted = false;

            if (ModelState.IsValid)
            {

                status = employeeBll.Create(employee);
                if (status == true)
                {

                    ViewBag.Msg = "Employee Successfully Added";
                    ModelState.Clear();
                    return View();
                }
                if (status == false)
                {

                    ViewBag.Msg = "Employee Added Failed !";
                }

            }
            return View(employee);
        }



        //Update Employee  [Get Request]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Employee employee = employeeBll.GetById(id);

            if (employee == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            return View(employee);
        }



        //Update Employee Category [Post Request]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee employee, HttpPostedFileBase ImageFile, byte[] CurrentImage)
        {

            if (ImageFile == null)
            {

                employee.Image = CurrentImage;
            }

            if (ImageFile != null)
            {
                bool isValidFormat = common.CheckImageFormat(ImageFile);
                if (isValidFormat == false)
                {
                    employee.Image = CurrentImage;
                    ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
                }
                else
                {
                    employee.Image = common.ConvertImage(ImageFile);
                }

            }

            if (ModelState.IsValid)
            {

                status = employeeBll.Update(employee);
                if (status == true)
                {
                    return RedirectToAction("ShowAll");
                }
                if (status == false)
                {

                    ViewBag.Msg = "Employee Category Added Failed !";
                }

            }
            return View(employee);
        }




        [HttpPost]
            //Delete Employee [Post Request]
            public JsonResult Delete(int id)
            {
                status = employeeBll.Delete(id);
                if (status)
                {
                    return Json(1);
                }
                return Json(0);
            }



            //Show All Employee
            public ActionResult ShowAll()
            {

                List<Employee> listOfEmployee = employeeBll.GetAll();
                return View(listOfEmployee);
            }


            //Show Employee Detail
            public ActionResult Details(int? id)
            {
                Employee employee = employeeBll.GetById(id);
                return PartialView("Details_Partial", employee);
            }


            //Get All Parent Category
            public JsonResult GetParentCategories()
            {
                var listOfEmployee = employeeBll.GetParentCategories();

                return Json(listOfEmployee, JsonRequestBehavior.AllowGet);
            }


            //Generating Random Category Code
            public JsonResult GetEmployeeCode()
            {
                string employeeCode = employeeBll.GetEmployeeCode();
                return Json(employeeCode);
            }


            //Checking Employee Name Availability
            public JsonResult CheckEmployeeName(string employeeEmail)
            {
                status = employeeBll.CheckEmployeeEmail(employeeEmail);
                if (status == true)
                {
                    return Json(1);
                }
                return Json(0);


            }
        }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Assignment3.Controllers
{
    public class EmployeeBase
    {
        public EmployeeBase()
        {
            LastName = "";
            FirstName = "";
            Title = "";
            BirthDate = DateTime.Now;
            HireDate = DateTime.Now;
            Address = "";
            City = "";
            State = "";
            Country = "";
            PostalCode = "";
            Phone = "";
            Fax = "";
            Email = "";
        }

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }


        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }
    }

    public class EmployeeEditForm
    {
        public EmployeeEditForm() { }
        [Key]
        public int EmployeeId{ get; set; }

        //Will Display View
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        //Will Display View
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        [RegularExpression("[a-zA-Z]{1}[0-9]{1}[a-zA-Z]{1}\\s*[0-9]{1}[a-zA-Z]{1}[0-9]{1}", ErrorMessage = "Only A1A 1A1 format allowed")]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Passwrod")]
        [RegularExpression("(?=.*\\d).{4,8}", ErrorMessage = "Password must be between 4 and 8 digits long and include at least one numeric digit.")]
        public string Password { get; set; }

        [Display(Name = "Number of weeks vacation")]
        [Range(2,6, ErrorMessage = "Must range from 2 to 6")]
        public int NumberOfVacation { get; set; }
    }
    public class EmployeeEdit
    {
        public EmployeeEdit() { }

        [Key]
        public int EmployeeId { get; set; }

        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }
    }
}
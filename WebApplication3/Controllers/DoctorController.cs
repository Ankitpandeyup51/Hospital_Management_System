using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        string cs = System.Configuration
              .ConfigurationManager
              .ConnectionStrings["MyConnection"]
              .ConnectionString;


        // SELECT
        public ActionResult Index()
        {
            List<Doctor> doctors =
                new List<Doctor>();

            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query =
                    "SELECT * FROM Doctor ORDER BY DoctorId DESC";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Doctor doctor =
                        new Doctor();

                    doctor.DoctorId =
                        (int)dr["DoctorId"];

                    doctor.DoctorName =
                        dr["DoctorName"].ToString();

                    doctor.Email =
                        dr["Email"].ToString();

                    doctor.Phone =
                        dr["Phone"].ToString();

                    doctor.Specialization =
                        dr["Specialization"].ToString();

                    doctor.Experience =
                        (int)dr["Experience"];

                    doctor.IsActive =
                        (bool)dr["IsActive"];

                    doctors.Add(doctor);
                }
            }

            return View(doctors);
        }


        // INSERT GET
        public ActionResult Create()
        {
            return View();
        }


        // INSERT POST
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    INSERT INTO Doctor
                    (
                        DoctorName,
                        Email,
                        Phone,
                        Specialization,
                        Experience,
                        IsActive
                    )
                    VALUES
                    (
                        @DoctorName,
                        @Email,
                        @Phone,
                        @Specialization,
                        @Experience,
                        @IsActive
                    )";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@DoctorName",
                    doctor.DoctorName
                );

                cmd.Parameters.AddWithValue(
                    "@Email",
                    doctor.Email ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    doctor.Phone ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Specialization",
                    doctor.Specialization ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Experience",
                    doctor.Experience
                );

                cmd.Parameters.AddWithValue(
                    "@IsActive",
                    doctor.IsActive
                );

                con.Open();

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }


        // UPDATE GET
        public ActionResult Edit(int id)
        {
            Doctor doctor =
                new Doctor();

            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query =
                    "SELECT * FROM Doctor WHERE DoctorId=@Id";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@Id",
                    id
                );

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    doctor.DoctorId =
                        (int)dr["DoctorId"];

                    doctor.DoctorName =
                        dr["DoctorName"].ToString();

                    doctor.Email =
                        dr["Email"].ToString();

                    doctor.Phone =
                        dr["Phone"].ToString();

                    doctor.Specialization =
                        dr["Specialization"].ToString();

                    doctor.Experience =
                        (int)dr["Experience"];

                    doctor.IsActive =
                        (bool)dr["IsActive"];
                }
            }

            return View(doctor);
        }


        // UPDATE POST
        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    UPDATE Doctor
                    SET
                        DoctorName=@DoctorName,
                        Email=@Email,
                        Phone=@Phone,
                        Specialization=@Specialization,
                        Experience=@Experience,
                        IsActive=@IsActive
                    WHERE DoctorId=@DoctorId";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@DoctorId",
                    doctor.DoctorId
                );

                cmd.Parameters.AddWithValue(
                    "@DoctorName",
                    doctor.DoctorName
                );

                cmd.Parameters.AddWithValue(
                    "@Email",
                    doctor.Email ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    doctor.Phone ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Specialization",
                    doctor.Specialization ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Experience",
                    doctor.Experience
                );

                cmd.Parameters.AddWithValue(
                    "@IsActive",
                    doctor.IsActive
                );

                con.Open();

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }


        // DELETE
        public ActionResult Delete(int id)
        {
            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query =
                    "DELETE FROM Doctor WHERE DoctorId=@Id";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@Id",
                    id
                );

                con.Open();

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}
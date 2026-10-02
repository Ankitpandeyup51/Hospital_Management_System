using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        string cs = System.Configuration
            .ConfigurationManager
            .ConnectionStrings["MyConnection"]
            .ConnectionString;


        // ==========================================
        // SELECT - ALL PATIENTS
        // ==========================================

        public ActionResult Index(string search)
        {
            List<Patient> patients =
                new List<Patient>();

            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    SELECT *
                    FROM Patient
                    WHERE
                        PatientName LIKE @Search
                        OR Phone LIKE @Search
                        OR Disease LIKE @Search
                    ORDER BY PatientId DESC";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@Search",
                    "%" + (search ?? "") + "%"
                );

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Patient patient =
                        new Patient();

                    patient.PatientId =
                        (int)dr["PatientId"];

                    patient.PatientName =
                        dr["PatientName"].ToString();

                    patient.Email =
                        dr["Email"].ToString();

                    patient.Phone =
                        dr["Phone"].ToString();

                    patient.Gender =
                        dr["Gender"].ToString();

                    if (dr["Age"] != System.DBNull.Value)
                    {
                        patient.Age =
                            (int)dr["Age"];
                    }

                    patient.Address =
                        dr["Address"].ToString();

                    patient.Disease =
                        dr["Disease"].ToString();

                    patient.BloodGroup =
                        dr["BloodGroup"].ToString();

                    patient.AdmissionDate =
                        (System.DateTime)
                        dr["AdmissionDate"];

                    patient.IsActive =
                        (bool)dr["IsActive"];

                    patients.Add(patient);
                }
            }

            ViewBag.Search = search;

            return View(patients);
        }


        // ==========================================
        // SELECT - SINGLE PATIENT
        // ==========================================

        public ActionResult Details(int id)
        {
            Patient patient =
                new Patient();

            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    SELECT *
                    FROM Patient
                    WHERE PatientId = @PatientId";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@PatientId",
                    id
                );

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    patient.PatientId =
                        (int)dr["PatientId"];

                    patient.PatientName =
                        dr["PatientName"].ToString();

                    patient.Email =
                        dr["Email"].ToString();

                    patient.Phone =
                        dr["Phone"].ToString();

                    patient.Gender =
                        dr["Gender"].ToString();

                    if (dr["Age"] != System.DBNull.Value)
                    {
                        patient.Age =
                            (int)dr["Age"];
                    }

                    patient.Address =
                        dr["Address"].ToString();

                    patient.Disease =
                        dr["Disease"].ToString();

                    patient.BloodGroup =
                        dr["BloodGroup"].ToString();

                    patient.AdmissionDate =
                        (System.DateTime)
                        dr["AdmissionDate"];

                    patient.IsActive =
                        (bool)dr["IsActive"];
                }
                else
                {
                    return HttpNotFound();
                }
            }

            return View(patient);
        }


        // ==========================================
        // INSERT - GET
        // ==========================================

        public ActionResult Create()
        {
            return View();
        }


        // ==========================================
        // INSERT - POST
        // ==========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    INSERT INTO Patient
                    (
                        PatientName,
                        Email,
                        Phone,
                        Gender,
                        Age,
                        Address,
                        Disease,
                        BloodGroup,
                        IsActive
                    )
                    VALUES
                    (
                        @PatientName,
                        @Email,
                        @Phone,
                        @Gender,
                        @Age,
                        @Address,
                        @Disease,
                        @BloodGroup,
                        @IsActive
                    )";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@PatientName",
                    patient.PatientName
                );

                cmd.Parameters.AddWithValue(
                    "@Email",
                    patient.Email ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    patient.Phone ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Gender",
                    patient.Gender ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Age",
                    (object)patient.Age ??
                    System.DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@Address",
                    patient.Address ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Disease",
                    patient.Disease ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@BloodGroup",
                    patient.BloodGroup ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@IsActive",
                    patient.IsActive
                );

                con.Open();

                cmd.ExecuteNonQuery();
            }

            TempData["Success"] =
                "Patient added successfully.";

            return RedirectToAction("Index");
        }


        // ==========================================
        // UPDATE - GET
        // ==========================================

        public ActionResult Edit(int id)
        {
            Patient patient =
                new Patient();

            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    SELECT *
                    FROM Patient
                    WHERE PatientId = @PatientId";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@PatientId",
                    id
                );

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    patient.PatientId =
                        (int)dr["PatientId"];

                    patient.PatientName =
                        dr["PatientName"].ToString();

                    patient.Email =
                        dr["Email"].ToString();

                    patient.Phone =
                        dr["Phone"].ToString();

                    patient.Gender =
                        dr["Gender"].ToString();

                    if (dr["Age"] != System.DBNull.Value)
                    {
                        patient.Age =
                            (int)dr["Age"];
                    }

                    patient.Address =
                        dr["Address"].ToString();

                    patient.Disease =
                        dr["Disease"].ToString();

                    patient.BloodGroup =
                        dr["BloodGroup"].ToString();

                    patient.IsActive =
                        (bool)dr["IsActive"];
                }
                else
                {
                    return HttpNotFound();
                }
            }

            return View(patient);
        }


        // ==========================================
        // UPDATE - POST
        // ==========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    UPDATE Patient
                    SET
                        PatientName = @PatientName,
                        Email = @Email,
                        Phone = @Phone,
                        Gender = @Gender,
                        Age = @Age,
                        Address = @Address,
                        Disease = @Disease,
                        BloodGroup = @BloodGroup,
                        IsActive = @IsActive
                    WHERE PatientId = @PatientId";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@PatientId",
                    patient.PatientId
                );

                cmd.Parameters.AddWithValue(
                    "@PatientName",
                    patient.PatientName
                );

                cmd.Parameters.AddWithValue(
                    "@Email",
                    patient.Email ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    patient.Phone ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Gender",
                    patient.Gender ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Age",
                    (object)patient.Age ??
                    System.DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@Address",
                    patient.Address ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@Disease",
                    patient.Disease ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@BloodGroup",
                    patient.BloodGroup ?? ""
                );

                cmd.Parameters.AddWithValue(
                    "@IsActive",
                    patient.IsActive
                );

                con.Open();

                cmd.ExecuteNonQuery();
            }

            TempData["Success"] =
                "Patient updated successfully.";

            return RedirectToAction("Index");
        }


        // ==========================================
        // DELETE
        // ==========================================

        public ActionResult Delete(int id)
        {
            using (SqlConnection con =
                   new SqlConnection(cs))
            {
                string query = @"
                    DELETE FROM Patient
                    WHERE PatientId = @PatientId";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@PatientId",
                    id
                );

                con.Open();

                cmd.ExecuteNonQuery();
            }

            TempData["Success"] =
                "Patient deleted successfully.";

            return RedirectToAction("Index");
        }
    }
}
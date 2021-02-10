using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdvWeb.DataAccessLayer;

namespace AdvWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantCandidateController : ControllerBase
    {

        private readonly MyDBContext context;
        private readonly ILogger<ApplicantCandidateController> _logger;

        public ApplicantCandidateController(MyDBContext context, ILogger<ApplicantCandidateController> logger)
        {
            this.context = context;
            _logger = logger;
        }



        [HttpGet]
        public IEnumerable<ApplicantCandiddate> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ApplicantCandiddate
            {
                Date = DateTime.Now.AddDays(index),
                Fullname = rng.Next(-20, 55).ToString(),
                Email =  rng.Next(-20, 55).ToString() + "@co.com",
                id = index

            })
            .ToArray();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicantCandiddate>> GetApplicantCandidate(int id)
        {
           

            return new ApplicantCandiddate();
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, ApplicantCandiddate dCandidate)
        {
            dCandidate.id = id;

         
            return NoContent();
        }

        // POST: api/DCandidate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ApplicantCandiddate>> PostCandidate(ApplicantCandiddate dCandidate)
        {
            
            return CreatedAtAction("GetApplicantCandidate", new { id = 1 }, dCandidate);
        }



    }
}

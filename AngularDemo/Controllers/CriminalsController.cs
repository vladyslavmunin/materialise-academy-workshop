using AngularDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularDemo.Controllers
{
    public class CriminalsController : ApiController
    {
        static List<Criminal> criminals;
        static CriminalsController()
        {
            criminals = new List<Criminal>()
            {
                new Criminal
                {
                    ID = Guid.NewGuid(),
                    Name = "John Wilkes Booth",
                    Description ="Given that Booth was a well-known actor and the assassination of Lincoln "+
                    "occurred in a crowded theater, avenging the tragedy merely hinged on catching him while "+
                    "he was still catchable. With a plan in place, he immediately fled the scene of the crime "+
                    " to rural Southern Maryland, prompting the dispatch of federal troops and the offering of a $100,000 reward"+
                    " for information leading to his arrest. On April 26, 12 days after Booth killed Lincoln, Lieutenant Colonel Everton Conger found him in a barn belonging"+
                     " to the Garrett family in Caroline Country, Virginia. Booth refused to surrender, and Conger’s accompanying soldiers set the barn on fire. When he remained inside, he was shot and killed."+
                    " Although an autopsy later confirmed the identity of Booth, rumors have since persisted that he escaped and lived under an assumed name.",
                    Reward=100000

                },
                 new Criminal
                {
                    ID = Guid.NewGuid(),
                    Name = "Adam Yahiye Gadahn",

                    Description =@"Raised a Christian in California,
                                    Gadahn’ s conversion to Islam when he was 17 years old caused an immense personal
                                    change and fueled a newfound hatred for his native country. His devotion to the religion
                                    took him to Pakistan, where he began supporting jihad. Following the September 11th attacks, 
                                    he became a main communicator for Al Qaeda, eventually appearing in videos threatening attacks on U.S. soil.
                                    In 2006, he became the first American charged with treason in more than 50 years. Still at large, the State Department
                                    is offering $1 million for information leading to his arrest.",
                    Reward = 1000000

                },
                  new Criminal
                {
                    ID = Guid.NewGuid(),
                    Name = "Shanika S. Minor",
                    Description =@"Shanika S. Minor is wanted for murdering a woman 
                            who was nine months pregnant in Milwaukee, Wisconsin, on March 6, 2016. Due to the perceived notion
                            that the victim had disparaged Minor's family, Minor allegedly shot the victim, who then collapsed inside 
                            her residence and died in front of her two children. The victim's unborn child, due within a week, 
                            also died before emergency medical personnel arrived.",
                    Reward=100000

                }


            };
        }

        [HttpGet]
        public IEnumerable<CriminalDTO> Get()
        {
            return criminals.Select(ConvertToDto).ToList();
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var criminal = criminals.FirstOrDefault((p) => p.ID == id);
            CriminalDTO dto = ConvertToDto(criminal);
            if (criminal == null)
            {
                return NotFound();
            }
            return Ok(criminal);
        }

        [HttpPost]
        public IHttpActionResult Post(CriminalDTO dto)
        {
            Criminal criminal = ConvertToCriminal(dto);
            criminals.Add(criminal);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(CriminalDTO dto)
        {
            
            var criminalToUpdate = criminals.FirstOrDefault((p) => p.ID == dto.ID);
            if (criminalToUpdate == null)
            {
                return NotFound();
            }
            criminalToUpdate.Name = dto.Name;
            criminalToUpdate.Description = dto.Description;
            criminalToUpdate.Reward = dto.Reward;
            return Ok();
      
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var criminal = criminals.FirstOrDefault((p) => p.ID == id);
            if (criminal == null)
            {
                return NotFound();
            }
            criminals.Remove(criminal);
            return Ok();
        }

        private Criminal ConvertToCriminal(CriminalDTO dto)
        {
            return new Criminal
            {
                ID = Guid.NewGuid(),
                Description = dto.Description,
                Name = dto.Name,
                Reward = dto.Reward
            };
        }

        private CriminalDTO ConvertToDto(Criminal criminal)
        {
            return new CriminalDTO
            {
               ID= criminal.ID,
                Description = criminal.Description,
                Name = criminal.Name,
                Reward = criminal.Reward
            };
        }

    }
}

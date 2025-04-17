using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_csv.database;
using api_csv.database.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_csv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private dbContext _dbContext;

        public AnimaisController(dbContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_dbContext.Animals);
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {
            try
            {
                Animal animal = _dbContext.Animals.Find(a => a.Id == id);

                if (animal == null)
                    return NotFound();  //404

                return Ok(animal); //200
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);  //400
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Animal animal = _dbContext.Animals.Find(a => a.Id == id);

                if (animal == null)
                    return NotFound(); //404

                _dbContext.Animals.Remove(animal);

                return Ok(); //200

            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //400
            }
        }

        [HttpPatch("AlterarNome")]
        public ActionResult<Animal> AlterarNome([FromBody] Animal body)
        {
            if ((body == null) || (string.IsNullOrEmpty(body.Name)))
                return BadRequest(); //400

            Animal animal = _dbContext.Animals.Find(a => a.Id == body.Id);

            if (animal == null)
                return NotFound(); //404

            animal.Name = body.Name;
                return Ok(animal); //200
        }


        // método Post par adicionar um Animal
        [HttpPost]                      //FromBody porque vai pegar os dados do body
        public ActionResult<Animal> Post([FromBody] Animal body)
        {
            //se não tiver nada no body, retorna status code 400
            if (body == null)
                return BadRequest("Animal data is null"); //400


            //valida se todos os campos estão preenchidos
            if (string.IsNullOrEmpty(body.Name) ||
                string.IsNullOrEmpty(body.Classification) ||
                string.IsNullOrEmpty(body.Origin) ||
                string.IsNullOrEmpty(body.Reproduction) ||
                string.IsNullOrEmpty(body.Feedding))
            {
                return BadRequest("Tem campos Faltando"); //400
            }
                

            try
            {


                //
                // fazer o gerar o ID automático no body.id
                //


                // Adiciona o novo animal que foi passado pelo body
                _dbContext.Animals.Add(body);

                       //created action é o Status code que retorna quando um registro é criado
                return CreatedAtAction("Created" , body); //201
                
            }
            catch (Exception e)
            {
                //caso der qualquer erro, cai aqui
                return BadRequest(e.Message); //400
            }
        }


        [HttpPut("{id}")]
        public ActionResult<Animal> Update(int id, [FromBody] Animal updatedAnimal)
        {
            if (updatedAnimal == null || string.IsNullOrEmpty(updatedAnimal.Name))
                return BadRequest("Dados inválidos.");

            Animal existingAnimal = _dbContext.Animals.FirstOrDefault(a => a.Id == id);

            if (existingAnimal == null)
                return NotFound(); // 404

            // incrementando as propriedades do animal
            existingAnimal.Name = updatedAnimal.Name;
            existingAnimal.Classification = updatedAnimal.Classification;
            existingAnimal.Origin = updatedAnimal.Origin;
            existingAnimal.Reproduction = updatedAnimal.Reproduction;
            existingAnimal.Feedding = updatedAnimal.Feedding;

            //
            // fazer o comando pra gravar o animal alterado no arquivo
            //


            _dbContext.Animals.
            

            return Ok(existingAnimal); // 200
        }




    }
}
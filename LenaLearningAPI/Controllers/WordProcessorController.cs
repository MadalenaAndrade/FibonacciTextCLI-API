using System.ComponentModel.DataAnnotations;
using LenaLearning;
using LenaLearningAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static System.Net.Mime.MediaTypeNames;

namespace LenaLearningAPI.Controllers
{
    [ApiController]
    [Route("WordProcessor/text")]
    public class WordProcessorController : ControllerBase
    {
        private readonly WordProcessor _wordProcessor;

        public WordProcessorController(WordProcessor wordProcessor) //for Dependecy injection 8) 
        {
            _wordProcessor = wordProcessor;
        }
        

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(GetTextResponse))]
        public IActionResult GetText()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_wordProcessor.Text))
                {
                    return BadRequest("Text is not set");
                }
                return Ok(new GetTextResponse
                {
                    Text = _wordProcessor.Text,
                    Message = $"Text present in the processor: {_wordProcessor.Text}"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [SwaggerResponse(200, Type = typeof(PostTextResponse))]
        public IActionResult SetText([FromBody] string text)
        {
            try
            {
                _wordProcessor.Text = text;
                return Ok(new PostTextResponse
                {
                    Text = _wordProcessor.Text,
                    Message = "Text set sucessfully"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("word-count")]
        [SwaggerResponse(200, Type = typeof(CountWordsResponse))]
        public IActionResult CountWords()
        {
            try
            {
                return Ok(new CountWordsResponse
                {
                    Text = _wordProcessor.Text,
                    WordCount = _wordProcessor.CountWords(),
                    Message = $"Words count: {_wordProcessor.CountWords()}"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("entry-count")]
        [SwaggerResponse(200, Type = typeof(CountWordEntryResponse))]
        public IActionResult CountWordEntry([FromQuery] string word)
        {
            try
            {
                return Ok(new CountWordEntryResponse
                {
                    Text = _wordProcessor.Text,
                    WordEntry = word,
                    WordCount = _wordProcessor.CountWordEntry(word),
                    Message = $"Ocurrences of '{word}': {_wordProcessor.CountWordEntry(word)}"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("character-position")]
        [SwaggerResponse(200, Type = typeof(GetCharacterAtResponse))]
        public IActionResult GetCharactersAt([FromQuery] int position)
        {
            try
            {
                return Ok(new GetCharacterAtResponse
                {
                    Text = _wordProcessor.Text,
                    Position = position,
                    Character = (_wordProcessor.GetCharacterAt(position)).ToString(),
                    Message = $"The character at position {position} is '{_wordProcessor.GetCharacterAt(position)}'"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("word-position")]
        [SwaggerResponse(200, Type = typeof(GetWordInPositionResponse))]
        public IActionResult GetWordAtCharactersPosition([FromQuery] int position)
        {
            try
            {

                return Ok(new GetWordInPositionResponse
                {
                    Text = _wordProcessor.Text,
                    Position = position,
                    Word = _wordProcessor.GetWordAtCharacterPosition(position),
                    Message = $"The word at character position {position} is '{_wordProcessor.GetWordAtCharacterPosition(position)}'"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("word-number")]
        [SwaggerResponse(200, Type = typeof(GetWordByPositionResponse))]
        public IActionResult GetWordByPosition([FromQuery] int number)
        {
            try
            {
                return Ok(new GetWordByPositionResponse
                {
                    Text = _wordProcessor.Text,
                    WordNumber = number,
                    Word = _wordProcessor.GetWordByWordPosition(number),
                    Message = $"The word number {number} is '{_wordProcessor.GetWordByWordPosition(number)}'"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("phrases-count")]
        [SwaggerResponse(200, Type = typeof(GetPhraseCountResponse))]
        public IActionResult GetPhraseCount()
        {
            try
            {
                return Ok(new GetPhraseCountResponse
                {
                    Text = _wordProcessor.Text,
                    PhraseCount = _wordProcessor.GetPhraseCount(),
                    Message = $"Sentences count: {_wordProcessor.GetPhraseCount()}"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace iColleague_API.Controllers
{
    [Route("api/home/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        string connectionString;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        [HttpGet("getquestions")]
        public DataSet GetQuestions()
        {

            SQLConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_data");
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);


            return ds;
        }

        [HttpGet("getquestionsbyid")]
        public DataSet GetQuestionsById(int id)
        {

            SQLConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_data where id="+id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);


            return ds;
        }
    }
}

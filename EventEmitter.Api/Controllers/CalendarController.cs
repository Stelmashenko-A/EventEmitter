using System.Collections.Generic;
using System.Web.Http;
using EventEmitter.Queries.Calendar;

namespace EventEmitter.Api.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Calendar")]
    public class CalendarController : CommonController
    {
        [System.Web.Mvc.AllowAnonymous]
        [HttpPost]
        public IEnumerable<Event> Get([FromBody] CalendarQuery query)
        {
            if (query == null)
            {
                query = new CalendarQuery();
            }

            query.UserId = Account.Id;
            return QueryDispatcher.Ask<CalendarQuery,IEnumerable<Event>>(query);
        }
    }
}
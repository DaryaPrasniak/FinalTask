using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailFinalTask.Utilities.Configuration
{
    public static class Endpoints
    {
        public static readonly string GET_SECTION = "index.php?/api/v2/get_section/{section_id}";
        public static readonly string GET_MILESTONE = "index.php?/api/v2/get_milestone/{milestone_id}";   
        public static readonly string POST_MILESTONE = "index.php?/api/v2/add_milestone/{project_id}";
    }
}

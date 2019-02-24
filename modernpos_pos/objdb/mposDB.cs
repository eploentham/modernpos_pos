using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.objdb
{
    public class mPosDB
    {
        ConnectDB conn;

        public StaffDB stfDB;
        public FSexDB sexDB;
        public CompanyDB copDB;
        public FPrefixDB fpfDB;
        public DepartmentDB deptDB;
        public PositionDB posiDB;

        public mPosDB(ConnectDB c)
        {
            conn = c;
            initConfig();            
        }
        private void initConfig()
        {
            Console.WriteLine("mPosDB start");

            stfDB = new StaffDB(conn);
            sexDB = new FSexDB(conn);
            copDB = new CompanyDB(conn);
            deptDB = new DepartmentDB(conn);
            posiDB = new PositionDB(conn);

            Console.WriteLine("mPosDB end");
        }
    }
}

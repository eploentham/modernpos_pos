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
        public AreaDB areaDB;
        public TableDB tblDB;
        public RestaurantDB resDB;
        public FoodsCatDB foocDB;
        public FoodsTypeDB footDB;
        public FoodsDB fooDB;
        public FoodsCatSubDB fcbDB;
        public FoodsRecommendDB foorDB;
        public OrderDB ordDB;
        public BillDB bilDB;
        public BillDetailDB bildDB;

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
            fpfDB = new FPrefixDB(conn);
            areaDB = new AreaDB(conn);
            tblDB = new TableDB(conn);
            resDB = new RestaurantDB(conn);
            foocDB = new FoodsCatDB(conn);
            footDB = new FoodsTypeDB(conn);
            fooDB = new FoodsDB(conn);
            fcbDB = new FoodsCatSubDB(conn);
            foorDB = new FoodsRecommendDB(conn);
            ordDB = new OrderDB(conn);
            bilDB = new BillDB(conn);
            bildDB = new BillDetailDB(conn);

            Console.WriteLine("mPosDB end");
        }
    }
}

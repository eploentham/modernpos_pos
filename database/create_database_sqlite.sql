DROP TABLE IF EXISTS b_area;
DROP TABLE IF EXISTS b_company;
DROP TABLE IF EXISTS b_department;
DROP TABLE IF EXISTS b_foods;
DROP TABLE IF EXISTS b_foods_category;
DROP TABLE IF EXISTS b_foods_category_sub;
DROP TABLE IF EXISTS b_foods_material;
DROP TABLE IF EXISTS b_foods_recommend;
DROP TABLE IF EXISTS b_foods_special;
DROP TABLE IF EXISTS b_foods_topping;
DROP TABLE IF EXISTS b_foods_type;
DROP TABLE IF EXISTS b_material;
DROP TABLE IF EXISTS b_material_type;
DROP TABLE IF EXISTS b_noodle_make;
DROP TABLE IF EXISTS b_position;
DROP TABLE IF EXISTS b_prefix;
DROP TABLE IF EXISTS b_printername;
DROP TABLE IF EXISTS b_restaurant;
DROP TABLE IF EXISTS b_staff;
DROP TABLE IF EXISTS b_table;
DROP TABLE IF EXISTS b_unit;

DROP TABLE IF EXISTS b_user;
DROP TABLE IF EXISTS f_doc_type;
DROP TABLE IF EXISTS f_prefix;
DROP TABLE IF EXISTS f_sex;
DROP TABLE IF EXISTS sequence;
DROP TABLE IF EXISTS t_bill;
DROP TABLE IF EXISTS t_bill_detail;
DROP TABLE IF EXISTS t_closeday;
DROP TABLE IF EXISTS t_material_draw;
DROP TABLE IF EXISTS t_material_draw_detail;
DROP TABLE IF EXISTS t_material_rec;
DROP TABLE IF EXISTS t_material_rec_detail;
DROP TABLE IF EXISTS t_order;
DROP TABLE IF EXISTS t_order_material;
DROP TABLE IF EXISTS t_order_special;
DROP TABLE IF EXISTS t_order_topping;
DROP TABLE IF EXISTS t_stock;
DROP TABLE IF EXISTS t_stock_endyear;
DROP TABLE IF EXISTS vne_close_day;
DROP TABLE IF EXISTS vne_request_payment;
DROP TABLE IF EXISTS vne_response_payment;


CREATE TABLE b_area(
   area_id INTEGER  PRIMARY KEY AUTOINCREMENT    NOT NULL,
   area_code      TEXT    NULL,
   area_name      TEXT    NULL,
   active      TEXT    NULL,
   remark      TEXT    NULL,
   sort1      TEXT    NULL,
   date_create      TEXT    NULL,
   date_modi      TEXT    NULL,
   date_cencel      TEXT    NULL,
   host_id      TEXT    NULL,
   branch_id      TEXT    NULL,
   device_id      TEXT    NULL,
   user_create      TEXT    NULL,
   user_modi      TEXT    NULL,
   user_cancel      TEXT    NULL,
   status_aircondition      TEXT    NULL
   );

CREATE TABLE b_company (
  comp_id INTEGER  PRIMARY KEY AUTOINCREMENT    NOT NULL ,
  comp_code TEXT NULL,
  comp_name_t TEXT NULL,
  comp_name_e TEXT NULL,
  comp_address_e TEXT NULL,
  comp_address_t TEXT NULL,
  addr1 TEXT NULL,
  addr2 TEXT NULL,
  amphur_id TEXT NULL,
  district_id TEXT NULL,
  province_id TEXT NULL,
  zipcode TEXT NULL,
  tele TEXT NULL,
  fax TEXT NULL,
  email TEXT NULL,
  website TEXT NULL,
  logo TEXT NULL,
  tax_id TEXT NULL,
  vat TEXT NULL,
  spec1 TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  qu_line1 TEXT NULL,
  qu_line2 TEXT NULL,
  qu_line3 TEXT NULL,
  qu_line4 TEXT NULL,
  qu_line5 TEXT NULL,
  qu_line6 TEXT NULL,
  inv_line1 TEXT NULL,
  inv_line2 TEXT NULL,
  inv_line3 TEXT NULL,
  inv_line4 TEXT NULL,
  inv_line5 TEXT NULL,
  inv_line6 TEXT NULL,
  po_line1 TEXT NULL,
  po_due_period TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  taddr1 TEXT NULL,
  taddr2 TEXT NULL,
  taddr3 TEXT NULL,
  taddr4 TEXT NULL,
  eaddr1 TEXT NULL,
  eaddr2 TEXT NULL,
  eaddr3 TEXT NULL,
  eaddr4 TEXT NULL,
  cash_draw_doc INTEGER  NULL ,
  year_curr TEXT NULL,
  amount_reserve decimal(17,2)  NULL ,
  billing_doc INTEGER  NULL ,
  tax1 TEXT NULL ,
  tax3 TEXT NULL ,
  tax53 TEXT NULL ,
  receipt_doc INTEGER  NULL  ,
  vat_doc INTEGER  NULL ,
  billing_cover_doc INTEGER  NULL ,
  rec_doc INTEGER  NULL ,
  month_curr TEXT NULL,
  prefix_billing_doc TEXT NULL,
  prefix_receipt_doc TEXT NULL,
  prefix_billing_cover_doc TEXT NULL,
  prefix_rec_doc TEXT NULL,
  queue_1_doc INTEGER  NULL,
  prefix_queue_1_doc TEXT NULL,
  draw_doc INTEGER  NULL,
  prefix_draw_doc TEXT NULL,
  vn_doc INTEGER  NULL,
  prefix_vn_doc TEXT NULL,
  queue_doc INTEGER  NULL,
  current_date1 TEXT NULL,
  form_a_doc INTEGER  NULL,
  prefix_form_a TEXT NULL,
  fet_doc INTEGER  NULL,
  prefix_fet_doc TEXT NULL,
  day_curr TEXT NULL
  
) 

CREATE TABLE b_department (
  dept_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  dept_code TEXT NULL,
  dept_name_t TEXT NULL,
  comp_id INTEGER  NULL,
  dept_parent_id INTEGER  NULL,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  active TEXT NULL,
  sort1 TEXT NULL
  
) 

CREATE TABLE b_foods (
  foods_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_code TEXT NULL,
  foods_name TEXT NULL,
  foods_price REAL  NULL,
  active TEXT NULL,
  foods_type_id INTEGER  NULL,
  remark TEXT NULL,
  res_id TEXT NULL,
  res_code TEXT NULL,
  status_foods TEXT NULL ,
  printer_name TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  sort1 TEXT NULL,
  foods_cat_id INTEGER  NULL,
  status_to_go TEXT NULL ,
  status_dine_in TEXT NULL ,
  filename TEXT NULL,
  status_recommend TEXT NULL,
  status_create TEXT ,
  price_plus_togo REAL  NULL,
  foods_name_1 TEXT  NULL
  
) 

CREATE TABLE b_foods_category (
  foods_cat_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_cat_code TEXT NULL,
  foods_cat_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  sort1 TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  status_foods TEXT NULL ,
  filename TEXT NULL,
  status_recommend TEXT 
 
) 

CREATE TABLE b_foods_category_sub (
  foods_cat_sub_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_cat_sub_code TEXT NULL,
  foods_cat_sub_name TEXT NULL,
  foods_cat_id INTEGER  NULL,
  active TEXT NULL,
  remark TEXT NULL,
  sort1 TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL
 
) 

CREATE TABLE b_foods_material (
  foods_material_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_id INTEGER  NULL,
  material_id INTEGER  NULL,
  material_name TEXT NULL,
  price REAL  NULL,
  weight REAL  NULL,
  active TEXT NULL,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  qty REAL  NULL ,
  sort1 TEXT NULL,
  unit_id INTEGER  NULL,
  unit_cal_id INTEGER  NULL
  
) 

CREATE TABLE b_foods_recommend (
  recom_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_id TEXT NULL,
  foods_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  sort1 TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL
  
) 

CREATE TABLE b_foods_special (
  foods_spec_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_id INTEGER  NULL,
  foods_spec_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL
 
) 

CREATE TABLE b_foods_topping (
  foods_topping_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_id INTEGER  NULL,
  foods_topping_name TEXT NULL,
  price REAL  NULL,
  active TEXT NULL,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL
  
) 



CREATE TABLE b_foods_type (
  foods_type_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  foods_type_code TEXT NULL,
  foods_type_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  sort1 TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL
  
) 

CREATE TABLE b_material (
  material_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  material_name TEXT NULL,
  price REAL  NULL,
  weight REAL  NULL,
  active TEXT NULL,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  sort1 TEXT NULL,
  material_code TEXT NULL,
  material_type_id INTEGER  NULL,
  unit_id INTEGER  NULL,
  unit_cal_id INTEGER  NULL,
  onhand REAL  
  
) 

CREATE TABLE b_material_type (
  material_type_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  material_type_code TEXT NULL,
  material_type_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  sort1 TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL
  
)

CREATE TABLE b_noodle_make (
  noodle_make_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  noodle_make_name TEXT NULL,
  noodle_make_price REAL  NULL,
  noodle_make_where TEXT NULL,
  noodle_make_where1 TEXT NULL,
  active TEXT NULL
) 

CREATE TABLE b_position (
  posi_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  posi_code TEXT NULL,
  posi_name_t TEXT NULL,
  posi_name_e TEXT NULL,
  dept_id INTEGER  NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  sort1 TEXT NULL,
  status_doctor TEXT NULL,
  status_embryologist TEXT NULL
)

CREATE TABLE b_prefix (
  prefix_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  prefix_code TEXT NULL,
  prefix_name_t TEXT NULL,
  prefix_name_e TEXT NULL,
  active TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  remark TEXT NULL,
  status_doctor TEXT NULL,
  f_sex_id INTEGER  NULL
  
) 

CREATE TABLE b_printername (
  printer_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  printer_name TEXT NULL,
  active TEXT NULL,
  printer_ip TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  device_id TEXT NULL
  
)

CREATE TABLE b_restaurant (
  res_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  res_code TEXT NULL,
  res_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  default_res TEXT NULL,
  receipt_footer1 TEXT NULL,
  receipt_header1 TEXT NULL,
  receipt_footer2 TEXT NULL,
  receipt_header2 TEXT NULL,
  bill_code TEXT NULL,
  bill_month TEXT NULL,
  tax_id TEXT NULL,
  printer_foods1 TEXT NULL,
  printer_foods2 TEXT NULL,
  printer_foods3 TEXT NULL,
  printer_waterbar1 TEXT NULL,
  printer_waterbar2 TEXT NULL,
  printer_waterbar3 TEXT NULL,
  sort1 TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  device_id TEXT NULL,
  cop_id INTEGER  NULL,
  receipt_header3 TEXT NULL,
  receipt_header4 TEXT NULL,
  receipt_header5 TEXT NULL,
  receipt_footer3 TEXT NULL,
  printer_bill_margin_top INTEGER  NULL,
  printer_bill_margin_left INTEGER  NULL,
  printer_bill_margin_right INTEGER  NULL,
  printer_bill_print_top INTEGER  NULL,
  printer_bill_print_left INTEGER  NULL,
  printer_bill_print_right INTEGER  NULL,
  receipt_footer4 TEXT NULL,
  receipt_footer5 TEXT NULL,
  status_print_order TEXT 
 
) 

CREATE TABLE b_staff (
  staff_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  staff_code TEXT NULL,
  username TEXT NULL,
  password1 TEXT NULL,
  prefix_id INTEGER  NULL,
  staff_fname_t TEXT NULL,
  staff_fname_e TEXT NULL,
  staff_lname_t TEXT NULL,
  staff_lname_e TEXT NULL,
  active TEXT NULL,
  priority TEXT NULL,
  tele TEXT NULL,
  mobile TEXT NULL,
  fax TEXT NULL,
  email TEXT NULL,
  posi_id TEXT NULL,
  posi_name TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  remark TEXT NULL,
  dept_id INTEGER  NULL,
  dept_name TEXT NULL,
  pid TEXT NULL,
  logo TEXT NULL,
  status_admin TEXT NULL ,
  status_module_reception TEXT NULL ,
  status_module_nurse TEXT NULL,
  status_module_doctor TEXT NULL,
  status_expense_draw TEXT NULL  ,
  status_expense_appv TEXT NULL ,
  status_expense_pay TEXT NULL  ,
  password_confirm TEXT NULL,
  status_module_pharmacy TEXT NULL,
  status_module_lab TEXT NULL
 
) 

CREATE TABLE b_table (
  table_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  area_id TEXT NULL,
  table_code TEXT NULL,
  table_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  sort1 TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  status_use TEXT NULL  ,
  status_togo TEXT NULL  ,
  date_use TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  status_reser TEXT NULL  
  
) 

CREATE TABLE b_unit (
  unit_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  unit_code TEXT NULL,
  unit_name TEXT NULL,
  active TEXT NULL,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  status_unit TEXT NULL  ,
  sort1 TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  device_id TEXT NULL,
  cal_unit REAL  NULL
  
) 

CREATE TABLE b_user (
  user_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  user_login TEXT NULL,
  user_name TEXT NULL,
  active TEXT NULL,
  password1 TEXT NULL,
  privilege TEXT NULL  ,
  remark TEXT NULL,
  date_create TEXT NULL,
  date_modi TEXT NULL,
  sort1 TEXT NULL,
  host_id TEXT NULL,
  branch_id TEXT NULL,
  permission_void_bill TEXT NULL,
  permission_void_closeday TEXT NULL,
  ttttt TEXT NULL,
  date_cancel TEXT NULL,
  user_create TEXT NULL,
  user_modi TEXT NULL,
  user_cancel TEXT NULL,
  device_id TEXT NULL
 
)

CREATE TABLE f_doc_type (
  doc_type_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  doc_type_code TEXT ,
  doc_type_name TEXT ,
  active TEXT ,
  status_combo TEXT 
 
) 

CREATE TABLE f_prefix (
  f_prefix_id INTEGER PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  prefix_description TEXT ,
  f_sex_id INTEGER  NULL,
  active TEXT 
  
)

CREATE TABLE f_sex (
  f_sex_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  sex_description TEXT ,
  active TEXT 
  
)

CREATE TABLE sequence (
  lotid INTEGER PRIMARY KEY  AUTOINCREMENT NOT NULL 
  
)  

CREATE TABLE t_bill (
  bill_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  bill_code TEXT ,
  bill_date TEXT ,
  lot_id TEXT ,
  active TEXT ,
  remark varchar(25) ,
  status_void TEXT ,
  void_date TEXT ,
  void_user TEXT ,
  table_id TEXT ,
  res_id TEXT ,
  area_id TEXT ,
  device_id TEXT ,
  amount REAL  NULL,
  discount REAL  NULL,
  service_charge REAL  NULL,
  vat REAL  NULL,
  total REAL  NULL,
  nettotal REAL  NULL,
  cash_receive REAL  NULL,
  cash_ton REAL  NULL,
  date_create TEXT ,
  date_modi TEXT ,
  bill_user TEXT ,
  status_closeday TEXT ,
  closeday_id TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  status_payment TEXT 
  
) 

CREATE TABLE t_bill_detail (
  bill_detail_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  bill_id INTEGER  NULL,
  order_id INTEGER  NULL,
  lot_id TEXT ,
  status_void TEXT ,
  row1 TEXT ,
  foods_id INTEGER  NULL,
  foods_code TEXT ,
  price REAL  NULL,
  qty REAL  NULL,
  amount REAL  NULL,
  date_create TEXT ,
  date_modi TEXT ,
  active TEXT ,
  remark TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  device_id TEXT 
  
) 

CREATE TABLE t_closeday (
  closeday_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  closeday_date TEXT ,
  res_id TEXT ,
  amount REAL  NULL,
  discount REAL  NULL,
  total REAL  NULL,
  service_charge REAL  NULL,
  vat REAL  NULL,
  nettotal REAL  NULL,
  remark TEXT ,
  active TEXT ,
  status_void TEXT ,
  void_date TEXT ,
  void_user TEXT ,
  cnt_bill REAL  NULL,
  bill_amount REAL  NULL,
  cnt_order REAL  NULL,
  amount_order REAL  NULL,
  closeday_user TEXT ,
  cash_receive1 REAL  NULL,
  cash_receive2 REAL  NULL,
  cash_receive3 REAL  NULL,
  cash_draw1 REAL  NULL,
  cash_draw2 REAL  NULL,
  cash_draw3 REAL  NULL,
  cash_receive1_remark TEXT ,
  cash_receive2_remark TEXT ,
  cash_receive3_remark TEXT ,
  cash_draw1_remark TEXT ,
  cash_draw2_remark TEXT ,
  cash_draw3_remark TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  weather TEXT  ,
  expense_1 REAL  NULL,
  expense_2 REAL  NULL,
  expense_3 REAL  NULL,
  expense_4 REAL  NULL,
  expense_5 REAL  NULL,
  cash_receive REAL  NULL,
  cash_ton REAL  NULL,
  amt_cash REAL  NULL,
  amt_credit_card REAL  NULL
  
) 

CREATE TABLE t_material_draw (
  matd_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  matd_code TEXT ,
  matd_date TEXT ,
  active TEXT ,
  remark TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  year_id TEXT ,
  status_stock TEXT  ,
  status_stock_year TEXT  ,
  date_gen_stock TEXT 
  
) 

CREATE TABLE t_material_draw_detail (
  matd_detail_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  matd_id INTEGER  NULL,
  material_id INTEGER  NULL,
  row1 int(11)  NULL,
  price decimal(17,4)  NULL,
  qty decimal(17,4)  NULL,
  weight decimal(17,4)  NULL,
  remark TEXT ,
  active TEXT ,
  sort1 TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  status_stock TEXT ,
  date_gen_stock TEXT 
  
) 

CREATE TABLE t_material_rec (
  matr_id INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL ,
  matr_code TEXT ,
  matr_date TEXT ,
  active TEXT ,
  remark TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  year_id TEXT ,
  status_stock TEXT  ,
  status_stock_year TEXT  ,
  date_gen_stock TEXT 
 
) 

CREATE TABLE t_material_rec_detail (
  matr_detail_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  matr_id INTEGER  NULL,
  material_id INTEGER  NULL,
  row1 int(11)  NULL,
  price decimal(17,4)  NULL,
  qty decimal(17,4)  NULL,
  weight decimal(17,4)  NULL,
  remark TEXT ,
  active TEXT ,
  sort1 TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  status_stock TEXT ,
  date_gen_stock TEXT 
  
) 

CREATE TABLE t_order (
  order_id INTEGER  PRIMARY KEY  AUTOINCREMENT NOT NULL ,
  lot_id int(11)  NULL,
  row1 int(11)  NULL,
  foods_id INTEGER  NULL,
  foods_code TEXT ,
  foods_name TEXT ,
  order_date TEXT ,
  price decimal(10,0)  NULL,
  qty decimal(10,0)  NULL,
  remark TEXT ,
  table_id INTEGER  NULL,
  res_id INTEGER  NULL,
  area_id INTEGER  NULL,
  status_foods_1 varchar(55) ,
  status_foods_2 varchar(55) ,
  status_foods_3 varchar(55) ,
  status_bill varchar(55)  ,
  bill_check_date varchar(55) ,
  status_cook varchar(55)  ,
  cook_receive_date varchar(55) ,
  cook_finish_date varchar(55) ,
  active varchar(55) ,
  void_date varchar(55) ,
  status_void varchar(55) ,
  printer_name TEXT ,
  status_to_go varchar(55)  ,
  bill_id int(11)  NULL,
  order_user TEXT ,
  status_closeday varchar(55) ,
  closeday_id INTEGER  NULL,
  host_id varchar(55) ,
  branch_id varchar(55) ,
  device_id varchar(55) ,
  date_create varchar(55) ,
  date_modi varchar(55) ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  cnt_cust TEXT ,
  year_id TEXT ,
  month_id TEXT ,
  day_id TEXT ,
  hour_id TEXT ,
  price_plus_togo REAL  NULL
  
) 

CREATE TABLE t_order_material (
  order_material_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  material_id INTEGER  NULL,
  foods_id TEXT ,
  order_id INTEGER  NULL,
  foods_material_id INTEGER  NULL,
  material_name TEXT ,
  foods_name TEXT ,
  price REAL  NULL,
  weight decimal(17,4)  NULL,
  active TEXT ,
  remark TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  sort1 TEXT ,
  qty decimal(17,4)  NULL,
  year_id TEXT ,
  month_id TEXT ,
  day_id TEXT ,
  hour_id TEXT 
  
) 

CREATE TABLE t_order_special (
  order_special_id INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL ,
  order_id INTEGER  NULL,
  foods_spec_id INTEGER  NULL,
  active TEXT ,
  remark TEXT ,
  row1 TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT 
  
) 

CREATE TABLE t_order_topping (
  order_topping_id INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL ,
  order_id INTEGER  NULL,
  foods_topping_id INTEGER  NULL,
  active TEXT ,
  remark TEXT ,
  row1 TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  qty REAL  ,
  price REAL  
  
) 

CREATE TABLE t_stock (
  stock_id INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL ,
  material_id INTEGER  NULL,
  price decimal(17,4)  NULL,
  qty decimal(17,4)  NULL,
  weight decimal(17,4)  NULL,
  rec_draw_matr_id INTEGER  ,
  status_rec_draw TEXT ,
  rec_draw_date TEXT ,
  active TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  remark TEXT ,
  sort1 TEXT ,
  onhand decimal(17,4)  NULL,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT ,
  amount decimal(17,4)  NULL
  
) 
CREATE TABLE t_stock_endyear (
  stock_endyear_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  material_id INTEGER  NULL,
  year_id TEXT ,
  rec_draw_matr_id INTEGER  NULL,
  price decimal(17,4)  NULL,
  qty decimal(17,4)  NULL,
  weight decimal(17,4)  NULL,
  status_rec_draw TEXT ,
  rec_draw_date TEXT ,
  active TEXT ,
  date_create TEXT ,
  dae_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT ,
  remark TEXT ,
  sort1 TEXT ,
  onhand decimal(17,4)  NULL,
  host_id TEXT ,
  branch_id TEXT ,
  device_id TEXT 
  
) 

CREATE TABLE vne_close_day (
  close_day_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  close_day_date TEXT ,
  req_status TEXT ,
  date1 TEXT ,
  date_start TEXT ,
  total_in TEXT ,
  total_out TEXT ,
  total_payments TEXT ,
  total_operator_in TEXT ,
  total_operaor_out TEXT ,
  total_content TEXT ,
  active TEXT ,
  remark TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT 
  
) 

CREATE TABLE vne_request_payment (
  request_payment_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  tipo TEXT ,
  importo TEXT ,
  opname TEXT ,
  operatore TEXT ,
  active TEXT ,
  remark TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT 
  
)

CREATE TABLE vne_response_payment (
  response_payemnt_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
  id TEXT ,
  importo TEXT ,
  tipo TEXT ,
  req_status TEXT ,
  active TEXT ,
  remark TEXT ,
  date_create TEXT ,
  date_modi TEXT ,
  date_cancel TEXT ,
  user_create TEXT ,
  user_modi TEXT ,
  user_cancel TEXT 
  
) 

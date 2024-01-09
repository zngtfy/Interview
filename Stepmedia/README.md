FE (web có thể dùng reactjs / javascript / mvc / angular/ vuejs.., ưu tiên reactjs): cho phép người dùng nhập vào danh sách Customer (Full Name, Date of Birth - DOB, Email),
Shop (Name, Location) và Product (Name, Image, Price). Một Customer có thể mua nhiều Product ở nhiều Shop. Khi Customer thực hiện mua một Product cần xác định ngày giao hàng.
Một Shop có nhiều Product. Cần nhập ít nhất là 303 Customer, 30 Shop, và 30303 Product. Cho phép người dùng thực hiện tìm kiếm Product.

BE (.net/sql): lưu trữ Customer/Shop/Product vào database. Load dữ liệu từ database và tiến hành sắp xếp theo qui luật:
Customer.Email theo thứ tự alphabet tăng dần, Shop.Location theo thứ tự alphabet giảm dần, Product.Price theo thứ tự giảm dần
=> Kết quả sắp xếp sẽ được trả về FE để hiện thị lên UI (Nếu không đủ 303 Customer, 30 Shop, và 30303 Product, UI sẽ hiển thị thông báo lỗi Không Đủ Dữ Liệu). 

--> BE cần kiểm tra các đơn hàng Customer đã mua Product, và đổi trạng thái các đơn hàng từ New sang Active sau 48h kể từ thời điểm đơn hàng được tạo,
đồng thời gửi email đến Customer thông báo đơn hàng đã được Active. --> FE OUTPUT:

  Table Headers
  ------------------------------------------------------------------------
  Customer (Name - Email) | Shop (Name - Location)| Product (Name - Image- Price)
  ------------------------------------------------------------------------
  Customer (Name - Email) | Shop (Name - Location)| Product (Name - Image- Price)
  ------------------------------------------------------------------------
  Customer (Name - Email) | Shop (Name - Location)| Product (Name - Image- Price)
  ------------------------------------------------------------------------
  Customer (Name - Email) | Shop (Name - Location)| Product (Name - Image- Price)
  Customer (Name - Email) | Shop (Name - Location)| Product (Name - Image- Price)
  ------------------------------------------------------------------------
  Customer (Name - Email) | Shop (Name - Location)| Product (Name - Image- Price)
  ------------------------------------------------------------------------ 

==> làm video ngắn giải thích code flow và demo chạy tính năng trên UI
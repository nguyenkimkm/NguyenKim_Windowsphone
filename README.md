# NguyenKim_Windowsphone
API Foursquare
Chương trình tìm các vị trí xung quanh vị trí hiện tại.

Em chưa xử lý được các vấn đề tối ưu về mạng nên ở đây em xin ghi phần mô tả và chạy thử chương trình.

Chương trình xác định vị trí hiện tại sử dụng namespace Windows.Devices.Geolocation và tìm các địa điểm xung quanh vị trí hiện tại sử dụng API của Foursquare.

Chuỗi API sử dụng: "https://api.foursquare.com/v2/venues/search?client_id=C3ML2TDLI315P4WG2C0GSIHTLX3NTEG005P5UUAAKVODKB0R" +
                                            "&client_secret=LKACZPLHNPQ5TGN2HL1SIVAMU0Z2JGG0RMMDQV3NW3ARMTBE" +
                                            "&limit=50" +
                                            "&intent=browse" +
                                            "$radius=800" +
                                            "&v=20151225&ll=" + posTest.Latitude + "," + posTest.Longitude;
Sử dụng class Json để lấy các thông tin cần thiết từ chuỗi phản hồi (venues, location...).
Giao diện chương trình gồm 2 trang:
- Trang hiển thị danh sách các địa điểm xung quanh tìm được.
- Trang thông tin chi tiết của một địa điểm(ảnh đại diện, tên, địa chỉ ,khoảng cách...) hiển thị khi sự kiện list_SelectionChanged xảy ra.
Chương trình chảy thử với vị trí posTest.Latitude = 10.764102; posTest.Longitude = 106.656254;
Một số địa điểm tìm được:
 + Co.opmart Ly Thuong Kiet
 + Sân vận động Phú Thọ
 + The Flemington
 + Phuong Nam Bookstore (PNC)
 + Chè Người Hoa 3/2
 + Gu Viet
 + ...

using AdminLte.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdminLte.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            // 1. ตรวจสอบว่า User มีการ Login หรือยัง

            if (User !=null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    // 2. ดึงชื่อผู้ใช้
                    var userName = User.Identity.Name;

                    // 3. ดึง ID หรือ Claims อื่นๆ (ถ้าคุณใช้ Identity)
                    //var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                    //// 4. เช็ค Role เพื่อกำหนดเมนูที่จะแสดง
                    //if (User.IsInRole("Admin"))
                    //{
                    //    // โหลดเมนูสำหรับ Admin
                    //}
                }
            }

            // 1. สร้างรายการเมนู (Model)
            var menus = new List<MenuItem>
                        {
                            new MenuItem { Title = "Dashboard", Controller = "Home", Action = "Index", Icon = "fas fa-home" },
                            new MenuItem {
                                Title = "จัดการสินค้า", Icon = "fas fa-box",
                                Children = new List<MenuItem> {
                                    new MenuItem { Title = "รายการสินค้า", Controller = "Product", Action = "Index" },
                                    new MenuItem {
                                        Title = "ตั้งค่าขั้นสูง", Icon = "fas fa-tools", // <-- Level 2
                                        Children = new List<MenuItem> {
                                            new MenuItem { Title = "หมวดหมู่ (Level 3)", Controller = "Category", Action = "Index" },
                                            new MenuItem { Title = "หน่วยนับ (Level 3)", Controller = "Unit", Action = "Index" }
                                        }
                                    }
                                }
                            },
                             new MenuItem {
                                Title = "จัดการสินค้า", Icon = "fas fa-box",
                                Children = new List<MenuItem> {
                                    new MenuItem { Title = "รายการเบิก pdf", Controller = "OrderPoPdf", Action = "ImportPoList" },
                                    new MenuItem {
                                        Title = "ตั้งค่าขั้นสูง", Icon = "fas fa-tools", // <-- Level 2
                                        Children = new List<MenuItem> {
                                            new MenuItem { Title = "หมวดหมู่ (Level 3)", Controller = "OrderPoPdf", Action = "uploadFile" },
                                            new MenuItem { Title = "หน่วยนับ (Level 3)", Controller = "OrderPoPdf", Action = "SendToKTB" }
                                        }
                                    }
                                }
                            }
                        };
                               
            return View(menus);

        }
    }
}

using System.Collections.Generic;
using WebDKLichKham.Models.ViewModels;

namespace WebDKLichKham.Data
{
    public static class ArticleRepository
    {
        public static List<Article> GetAllArticles()
        {
            return new List<Article>
            {
                new()
                {
                    Id = "dau-hieu-tay-chan-mieng-chuyen-nang",
                    CategoryName = "Nhi khoa",
                    CategoryColor = "#0284c7",
                    Title = "Dấu hiệu cảnh báo bệnh tay chân miệng chuyển nặng ở trẻ nhỏ",
                    Description = "Nhận biết sớm các triệu chứng nguy hiểm của bệnh tay chân miệng để kịp thời đưa trẻ đến bệnh viện điều trị, tránh biến chứng nguy hiểm.",
                    ImageUrl = "https://images.unsplash.com/photo-1631815588090-d4bfec5b1ccb?q=80&w=800",
                    DateString = "15 Tháng 5, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Bệnh tay chân miệng ở trẻ em có thể diễn tiến rất nhanh chóng và dẫn tới nhiều biến chứng nguy hiểm như viêm não, viêm màng não, viêm cơ tim, phù phổi cấp. Theo hướng dẫn từ Bộ Y tế Việt Nam và Bệnh viện Nhi Trung ương, phụ huynh cần đặc biệt lưu ý các dấu hiệu cảnh báo dưới đây.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Bệnh tay chân miệng là gì?</h4>
                        <p class='mb-4'>Tay chân miệng là bệnh truyền nhiễm cấp tính do virus thuộc nhóm Enterovirus gây ra, phổ biến nhất là Coxsackievirus A16 và Enterovirus 71 (EV71). Bệnh thường gặp ở trẻ dưới 5 tuổi với các biểu hiện đặc trưng như sốt, loét miệng, phỏng nước ở lòng bàn tay, lòng bàn chân, mông hoặc gối.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Dấu hiệu nhận biết trẻ chuyển nặng (Độ 2 trở lên)</h4>
                        <p class='mb-3'>If thấy trẻ có một trong những biểu hiện sau, cha mẹ cần nhanh chóng đưa trẻ đến cơ sở y tế gần nhất:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>Giật mình chới với:</strong> Đây là dấu hiệu quan trọng nhất cảnh báo độc tố virus đã ảnh hưởng đến hệ thần kinh trung ương. Hãy chú ý xem trẻ có bị giật mình khi bắt đầu thiu thiu ngủ hoặc ngay cả khi đang chơi bình thường (tần suất trên 2 lần trong vòng 30 phút).</li>
                            <li><strong>Sốt cao liên tục khó hạ:</strong> Trẻ sốt trên 39 độ C kéo dài hơn 48 giờ và không đáp ứng với các loại thuốc hạ sốt thông thường như Paracetamol.</li>
                            <li><strong>Quấy khóc dai dẳng, lờ đờ hoặc ngủ gà:</strong> Trẻ quấy khóc cả đêm không ngủ được, cứ nằm xuống là khóc hoặc luôn trong trạng thái mệt mỏi, khó đánh thức.</li>
                            <li><strong>Run chi, đi đứng loạng choạng:</strong> Khi đi hoặc khi cầm nắm đồ vật, tay chân trẻ run rẩy, đi không vững, đứng loạng choạng.</li>
                            <li><strong>Nôn ói nhiều:</strong> Trẻ nôn trớ liên tục, ăn vào lại nôn, nôn khan mà không kèm theo tiêu chảy.</li>
                        </ul>
                        
                        <div class='bg-amber-50 border-l-4 border-amber-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-amber-800'>⚠️ Lưu ý đặc biệt:</p>
                            <p class='text-amber-700 text-sm'>Nếu trẻ xuất hiện dấu hiệu thở nhanh, thở khó, vã mồ hôi lạnh toàn thân, chi lạnh, huyết áp tăng cao hoặc da nổi vân tím, đây là giai đoạn cực kỳ nguy kịch (Độ 3, Độ 4). Cần gọi ngay cấp cứu hoặc đưa trẻ đến viện trong vòng vài phút.</p>
                        </div>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Cách chăm sóc trẻ tay chân miệng tại nhà an toàn</h4>
                        <ul class='list-decimal pl-5 mb-4 space-y-2'>
                            <li><strong>Hạ sốt đúng liều lượng:</strong> Dùng Paracetamol liều 10 - 15 mg/kg mỗi 4 - 6 giờ khi sốt trên 38.5 độ C. Tuyệt đối không tự ý dùng Aspirin hay Ibuprofen khi chưa có chỉ định của bác sĩ.</li>
                            <li><strong>Vệ sinh răng miệng và cơ thể:</strong> Sử dụng nước muối sinh lý ấm để súc miệng cho trẻ. Cho trẻ ăn thức ăn lỏng, mềm, nguội để tránh làm đau các vết loét trong miệng. Không kiêng tắm rửa, trái lại cần tắm rửa hàng ngày bằng nước ấm ở nơi kín gió để tránh nhiễm trùng da.</li>
                            <li><strong>Khử khuẩn đồ chơi và môi trường xung quanh:</strong> Cách ly trẻ bị bệnh với các trẻ khác. Rửa sạch tay bằng xà phòng trước và sau khi chăm sóc trẻ.</li>
                        </ul>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Cổng thông tin Cục Y tế Dự phòng - Bộ Y tế & Bệnh viện Nhi Trung ương.</p>
                    "
                },
                new()
                {
                    Id = "cac-moc-sieu-am-thai-ky-quan-trong",
                    CategoryName = "Sản phụ khoa",
                    CategoryColor = "#db2777",
                    Title = "Các cột mốc siêu âm thai kỳ quan trọng mẹ bầu cần ghi nhớ",
                    Description = "Siêu âm thai định kỳ giúp tầm soát dị tật bẩm sinh và theo dõi sự phát triển của thai nhi. Có 3 cột mốc siêu âm bắt buộc là tuần 11-13, tuần 20-24 và tuần 30-32.",
                    ImageUrl = "https://images.unsplash.com/photo-1584515933487-779824d29309?q=80&w=800",
                    DateString = "12 Tháng 5, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Siêu âm thai không đơn thuần chỉ là để nhìn thấy hình ảnh của con hay biết giới tính của bé, mà quan trọng hơn hết là kiểm soát dị tật thai nhi và phát hiện kịp thời các bất thường ở mẹ. Bệnh viện Phụ sản Từ Dũ và Phụ sản Trung ương khuyến nghị 3 mốc siêu âm bắt buộc dưới đây.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Mốc thứ nhất: Tuần 11 đến tuần 13 tuần 6 ngày</h4>
                        <p class='mb-2'>Đây là <strong>thời điểm vàng duy nhất</strong> để thực hiện các khảo sát sau:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li><strong>Đo độ mờ da gáy (Nuchal Translucency - NT):</strong> Tầm soát hội chứng Down, Edwards và Patau. Nếu vượt qua tuần thứ 14, da gáy sẽ trở về bình thường và việc đo không còn giá trị chẩn đoán chính xác nữa.</li>
                            <li><strong>Xác định tuổi thai và ngày dự sinh:</strong> Đo chiều dài đầu mông (CRL) ở giai đoạn này cho kết quả dự sinh chính xác nhất với độ sai số chỉ ±3 ngày.</li>
                            <li><strong>Xét nghiệm Double Test:</strong> Kết hợp siêu âm da gáy và lấy máu mẹ để tính toán nguy cơ dị tật nhiễm sắc thể.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Mốc thứ hai: Tuần 20 đến tuần 24 (Siêu âm hình thái học 4D/5D)</h4>
                        <p class='mb-2'>Ở mốc này, em bé đã phát triển tương đối đầy đủ các bộ phận bên trong và bên ngoài. Bác sĩ siêu âm sẽ khảo sát chi tiết từng milimet:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li><strong>Hình thể bên ngoài:</strong> Quan sát gương mặt (phát hiện sứt môi, hở hàm ếch), đếm ngón tay, ngón chân, cấu trúc tay chân.</li>
                            <li><strong>Cấu trúc cơ quan nội tạng:</strong> Kiểm tra các buồng tim, vách ngăn tim (phát hiện tim bẩm sinh), nhu mô phổi, cấu trúc não bộ, thận, bàng quang và cột sống.</li>
                            <li><strong>Khảo sát bánh nhau và nước ối:</strong> Phát hiện rau tiền đạo, rau bám thấp, đa ối hoặc thiếu ối.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Mốc thứ ba: Tuần 30 đến tuần 32 (Đánh giá tăng trưởng & Doppler màu)</h4>
                        <p class='mb-2'>Giai đoạn chuẩn bị về đích này hướng tới mục tiêu đánh giá sức khỏe toàn diện của thai nhi:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li><strong>Tầm soát dị tật muộn:</strong> Một số bất thường về tim, cấu trúc não bộ hoặc hệ tiêu hóa chỉ biểu hiện rõ ở những tháng cuối.</li>
                            <li><strong>Siêu âm Doppler màu:</strong> Đo lưu lượng máu trong động mạch rốn, động mạch não giữa của thai nhi nhằm phát hiện sớm tình trạng thai chậm phát triển trong tử cung hoặc thiếu oxy.</li>
                            <li><strong>Xác định ngôi thai:</strong> Đánh giá ngôi đầu, ngôi mông hay ngôi ngang để chuẩn bị phương án sinh thường hay sinh mổ.</li>
                        </ul>
                        
                        <div class='bg-pink-50 border-l-4 border-pink-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-pink-800'>💡 Lời khuyên y khoa:</p>
                            <p class='text-pink-700 text-sm'>Mẹ bầu cần đi khám đúng lịch hẹn của bác sĩ sản khoa. Việc siêu âm quá nhiều lần không cần thiết không mang lại thêm thông tin y tế mà gây tốn kém, nhưng bỏ qua các mốc quan trọng có thể làm mất đi cơ hội can thiệp sớm cho bé.</p>
                        </div>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Hướng dẫn quốc gia về dịch vụ Chăm sóc sức khỏe sinh sản - Bộ Y tế Việt Nam.</p>
                    "
                },
                new()
                {
                    Id = "huong-dan-bo-sung-d3-canxi-cho-tre-em",
                    CategoryName = "Dinh dưỡng",
                    CategoryColor = "#d97706",
                    Title = "Hướng dẫn bổ sung Vitamin D3 và Canxi chuẩn y khoa cho trẻ sơ sinh",
                    Description = "Vitamin D3 đóng vai trò quyết định trong việc hấp thụ canxi và phát triển xương ở trẻ em. Bổ sung thiếu hoặc thừa đều nguy hiểm đến sức khỏe của bé.",
                    ImageUrl = "https://images.unsplash.com/photo-1609220136736-443140cffec6?q=80&w=800",
                    DateString = "08 Tháng 5, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Canxi là nguyên liệu chính để xây dựng khung xương chắc khỏe cho bé, nhưng nếu thiếu Vitamin D3, chỉ có khoảng 10% lượng canxi từ thức ăn được hấp thụ vào máu. Viện Dinh dưỡng Quốc gia và Hiệp hội Nhi khoa thế giới khuyến nghị quy trình bổ sung an toàn như sau.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Vì sao trẻ sơ sinh dễ thiếu Vitamin D3?</h4>
                        <p class='mb-4'>Sữa mẹ là thức ăn tốt nhất cho trẻ sơ sinh nhưng lượng Vitamin D trong sữa mẹ rất thấp (chỉ khoảng 20 - 40 IU/lít, trong khi nhu cầu của trẻ là 400 IU/ngày). Việc tắm nắng cho trẻ sơ sinh hiện nay không còn được khuyến nghị rộng rãi để tổng hợp Vitamin D do nguy cơ tổn thương da bởi tia cực tím (UV) của ánh nắng mặt trời gay gắt.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Liều lượng bổ sung Vitamin D3 chuẩn y khoa</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>Trẻ bú mẹ hoàn toàn hoặc bú mẹ một phần:</strong> Cần được bổ sung Vitamin D3 liều 400 IU/ngày, bắt đầu từ vài ngày sau khi sinh.</li>
                            <li><strong>Trẻ uống sữa công thức hoàn toàn:</strong> Nếu trẻ uống ít hơn 1 lít sữa công thức mỗi ngày (đã bổ sung sẵn Vitamin D), mẹ vẫn cần bổ sung thêm D3 cho bé theo hướng dẫn của bác sĩ.</li>
                            <li><strong>Trẻ sinh non, sinh nhẹ cân:</strong> Thường cần liều cao hơn (từ 400 - 800 IU/ngày) và có thể kèm theo bổ sung sắt, canxi trực tiếp.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Khi nào cần bổ sung Canxi trực tiếp cho trẻ?</h4>
                        <p class='mb-3'>Tuyệt đối không tự ý mua canxi cho trẻ uống nếu không có chỉ định từ bác sĩ nhi khoa hoặc chuyên gia dinh dưỡng. Chỉ bổ sung canxi khi trẻ có các dấu hiệu thiếu hụt rõ rệt và được chẩn đoán lâm sàng:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li>Trẻ rụng tóc hình vành khăn sau gáy.</li>
                            <li>Trẻ hay quấy khóc, giật mình, đổ mồ hôi trộm nhiều khi ngủ.</li>
                            <li>Trẻ chậm mọc răng, chậm biết lẫy, biết đi, hoặc thóp trước rộng, chậm liền thóp.</li>
                        </ul>
                        
                        <div class='bg-amber-50 border-l-4 border-amber-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-amber-800'>⚠️ Nguy cơ khi bổ sung quá liều Canxi và D3:</p>
                            <p class='text-amber-700 text-sm'>Lạm dụng canxi có thể gây sỏi thận, vôi hóa mạch máu, táo bón nặng và làm cốt hóa xương sớm khiến trẻ bị lùn, hạn chế chiều cao khi trưởng thành. Thừa Vitamin D3 kéo dài gây ngộ độc Vitamin D, tăng canxi máu, làm trẻ chán ăn, buồn nôn, mệt mỏi.</p>
                        </div>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>4. Cách cho trẻ uống D3 đúng cách</h4>
                        <p class='mb-4'>Nên cho trẻ uống Vitamin D3 vào buổi sáng (trước hoặc ngay sau khi bú). Có thể nhỏ trực tiếp vào miệng trẻ hoặc nhỏ lên đầu ti của mẹ trước khi cho bú, hoặc pha vào một thìa sữa nhỏ. Tránh nhỏ trực tiếp từ chai vào miệng trẻ để tránh nhiễm khuẩn vòi nhỏ hoặc quá liều do quá tay.</p>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Tài liệu Hướng dẫn Dinh dưỡng Lâm sàng - Viện Dinh dưỡng Quốc gia Việt Nam.</p>
                    "
                },
                new()
                {
                    Id = "tam-soat-ung-thu-co-tu-cung",
                    CategoryName = "Phụ sản",
                    CategoryColor = "#7c3aed",
                    Title = "Tầm soát ung thư cổ tử cung: Giải pháp bảo vệ sức khỏe phụ nữ hiện đại",
                    Description = "Ung thư cổ tử cung là một trong những ung thư phổ biến nhất ở phụ nữ. Việc xét nghiệm Pap smear và HPV định kỳ giúp phát hiện sớm và điều trị thành công gần 100%.",
                    ImageUrl = "https://images.unsplash.com/photo-1559757148-5c350d0d3c56?q=80&w=800",
                    DateString = "05 Tháng 5, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Ung thư cổ tử cung là căn bệnh nguy hiểm thầm lặng, thường không có triệu chứng rõ ràng ở giai đoạn đầu. Tuy nhiên, đây lại là một trong số ít loại ung thư có thể phòng ngừa chủ động và điều trị khỏi hoàn toàn nếu phát hiện ở giai đoạn tiền ung thư nhờ tầm soát định kỳ.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Nguyên nhân chính gây ung thư cổ tử cung</h4>
                        <p class='mb-4'>Hơn 99% trường hợp ung thư cổ tử cung có liên quan chặt chẽ đến việc lây nhiễm virus Human Papillomavirus (HPV) chủng nguy cơ cao, phổ biến nhất là tuýp 16 và 18. Virus này lây truyền chủ yếu qua đường tình dục. Hệ miễn dịch cơ thể có thể tự đào thải HPV trong đa số trường hợp, nhưng nếu nhiễm virus kéo dài nhiều năm sẽ kích hoạt sự biến đổi bất thường của các tế bào cổ tử cung.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Các phương pháp tầm soát phổ biến hiện nay</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>Xét nghiệm Pap Smear (Phết tế bào cổ tử cung):</strong> Bác sĩ sẽ lấy tế bào ở cổ tử cung để soi dưới kính hiển vi nhằm tìm kiếm những biến đổi cấu trúc tế bào từ sớm. Đây là phương pháp kinh điển, chi phí thấp.</li>
                            <li><strong>Xét nghiệm HPV DNA:</strong> Sử dụng công nghệ sinh học phân tử để xác định sự hiện diện của DNA virus HPV chủng nguy cơ cao trực tiếp từ dịch cổ tử cung. Phương pháp này có độ nhạy cực cao (>95%).</li>
                            <li><strong>Phương pháp liên hợp (Co-testing):</strong> Thực hiện đồng thời cả Pap smear và xét nghiệm HPV DNA để nâng cao hiệu quả chẩn đoán chính xác tối đa.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Lịch tầm soát khuyến cáo cho từng độ tuổi</h4>
                        <table class='w-full border-collapse my-4 text-sm'>
                            <thead>
                                <tr class='bg-gray-100 text-left'>
                                    <th class='border p-2 font-bold'>Độ tuổi</th>
                                    <th class='border p-2 font-bold'>Khuyến cáo tầm soát</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class='border p-2 font-semibold'>Dưới 21 tuổi</td>
                                    <td class='border p-2'>Chưa cần tầm soát, tập trung tiêm phòng vắc xin HPV (độ tuổi tốt nhất từ 9 - 26 tuổi).</td>
                                </tr>
                                <tr>
                                    <td class='border p-2 font-semibold'>Từ 21 - 29 tuổi</td>
                                    <td class='border p-2'>Thực hiện xét nghiệm Pap smear định kỳ mỗi 3 năm/lần.</td>
                                </tr>
                                <tr>
                                    <td class='border p-2 font-semibold'>Từ 30 - 65 tuổi</td>
                                    <td class='border p-2'>Ưu tiên Co-testing mỗi 5 năm/lần, hoặc chỉ làm Pap smear mỗi 3 năm/lần.</td>
                                </tr>
                                <tr>
                                    <td class='border p-2 font-semibold'>Trên 65 tuổi</td>
                                    <td class='border p-2'>Có thể dừng tầm soát nếu kết quả tầm soát trước đó liên tục âm tính trong vòng 10 năm.</td>
                                </tr>
                            </tbody>
                        </table>
                        
                        <div class='bg-purple-50 border-l-4 border-purple-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-purple-800'>💡 Lưu ý quan trọng trước khi đi tầm soát:</p>
                            <ul class='list-disc pl-5 text-purple-700 text-sm space-y-1'>
                                <li>Không thực hiện xét nghiệm trong những ngày đang có kinh nguyệt (thời điểm tốt nhất là sau khi sạch kinh 3 - 5 ngày).</li>
                                <li>Tránh quan hệ tình dục, sử dụng màng ngăn âm đạo hoặc thuốc đặt phụ khoa trong vòng 48 giờ trước khi làm xét nghiệm.</li>
                            </ul>
                        </div>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Khuyến cáo của Hội Ung thư Hoa Kỳ (ACS) & Bệnh viện K Trung ương.</p>
                    "
                },
                new()
                {
                    Id = "phong-ngua-viem-phoi-tre-em-khi-giao-mua",
                    CategoryName = "Nhi khoa",
                    CategoryColor = "#059669",
                    Title = "Phòng ngừa viêm đường hô hấp cấp ở trẻ em khi thời tiết giao mùa",
                    Description = "Trẻ em rất dễ bị viêm phế quản, viêm phổi khi thời tiết chuyển mùa. Giữ ấm, tiêm vắc xin cúm, phế cầu và vệ sinh mũi họng là những biện pháp phòng ngừa hữu hiệu nhất.",
                    ImageUrl = "https://images.unsplash.com/photo-1607619662634-3ac55ec0e216?q=80&w=800",
                    DateString = "02 Tháng 5, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Viêm đường hô hấp cấp tính là nguyên nhân hàng đầu khiến trẻ em phải nhập viện điều trị, đặc biệt trong thời điểm giao mùa từ nóng sang lạnh hoặc khi độ ẩm không khí thay đổi đột ngột. Để bảo vệ đường hô hấp non nớt của trẻ, các bác sĩ nhi khoa khuyến nghị thực hiện tốt các nguyên tắc phòng bệnh chủ động sau.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Vì sao trẻ dễ bị viêm phổi khi giao mùa?</h4>
                        <p class='mb-4'>Hệ miễn dịch của trẻ em chưa hoàn thiện, đường thở ngắn và hẹp nên virus, vi khuẩn dễ xâm nhập và phát triển gây viêm phế quản, viêm phổi. Độ ẩm cao kết hợp nhiệt độ giảm tạo điều kiện thuận lợi cho các virus đường hô hấp phát triển mạnh mẽ (như virus cúm, virus hợp bào hô hấp RSV).</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. 4 nguyên tắc phòng ngừa viêm đường hô hấp hữu hiệu nhất</h4>
                        <ul class='list-decimal pl-5 mb-4 space-y-3'>
                            <li><strong>Tiêm vắc xin đầy đủ và đúng lịch:</strong> Đây là lá chắn bảo vệ kiên cố nhất cho trẻ. Cha mẹ cần tiêm đầy đủ các mũi vắc xin 5 trong 1 hoặc 6 trong 1, đặc biệt là vắc xin phế cầu khuẩn (Synflorix/Prevenar 13) chống viêm phổi, viêm tai giữa và vắc xin cúm mùa hàng năm cho trẻ từ 6 tháng tuổi.</li>
                            <li><strong>Giữ ấm cơ thể đúng cách:</strong> Chú ý giữ ấm các vùng nhạy cảm như cổ, ngực, lòng bàn tay, lòng bàn chân của trẻ. Tuy nhiên, tránh ủ ấm quá mức khiến trẻ ra mồ hôi lưng, mồ hôi thấm ngược lại cơ thể gây nhiễm lạnh.</li>
                            <li><strong>Vệ sinh mũi họng hàng ngày:</strong> Tập cho trẻ thói quen rửa tay bằng xà phòng trước khi ăn và sau khi đi vệ sinh. Dùng nước muối sinh lý ấm nhỏ mũi, nhỏ mắt hàng ngày để làm sạch đường hô hấp của bé sau khi đi ra ngoài về.</li>
                            <li><strong>Duy trì dinh dưỡng hợp lý:</strong> Cho trẻ bú mẹ hoàn toàn trong 6 tháng đầu đời để nhận kháng thể từ mẹ. Đối với trẻ lớn hơn, tăng cường thực phẩm giàu Vitamin C, Vitamin A (rau xanh, hoa quả tươi) để củng cố hệ miễn dịch tự nhiên.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Khi nào cần đưa trẻ đi khám bác sĩ?</h4>
                        <p class='mb-3'>Rất nhiều phụ huynh chủ quan tự ý mua kháng sinh điều trị ho cho trẻ tại nhà, dẫn đến biến chứng suy hô hấp. Hãy đưa trẻ đi khám ngay nếu có các biểu hiện:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li>Trẻ thở nhanh bất thường so với độ tuổi (trên 50 lần/phút ở trẻ dưới 1 tuổi, trên 40 lần/phút ở trẻ trên 1 tuổi).</li>
                            <li>Trẻ có dấu hiệu thở rút lõm lồng ngực (phần dưới xương sườn lõm sâu khi trẻ hít vào).</li>
                            <li>Trẻ sốt cao không hạ, bỏ bú, ngủ li bì, đánh thức không dậy.</li>
                        </ul>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Hướng dẫn chăm sóc và điều trị bệnh Nhi khoa - Bệnh viện Nhi Đồng 1.</p>
                    "
                },
                new()
                {
                    Id = "dinh-duong-cho-me-bau-tieu-duong-thai-ky",
                    CategoryName = "Dinh dưỡng",
                    CategoryColor = "#ea580c",
                    Title = "Chế độ dinh dưỡng cân bằng cho mẹ bầu bị đái tháo đường thai kỳ",
                    Description = "Đái tháo đường thai kỳ ảnh hưởng xấu đến cả mẹ và bé nếu không kiểm soát tốt đường huyết. Tìm hiểu thực đơn dinh dưỡng chuẩn giúp kiểm soát đường huyết hiệu quả.",
                    ImageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?q=80&w=800",
                    DateString = "28 Tháng 4, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Đái tháo đường thai kỳ là tình trạng rối loạn dung nạp glucose được phát hiện lần đầu tiên trong lúc mang thai, thường xảy ra ở tuần thứ 24 - 28. Chế độ ăn uống hợp lý đóng vai trò quyết định, giúp hơn 85% mẹ bầu kiểm soát tốt đường huyết mà không cần dùng đến thuốc tiêm insulin.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Nguyên tắc vàng trong xây dựng thực đơn</h4>
                        <p class='mb-3'>Mục tiêu là cung cấp đủ dinh dưỡng cho thai nhi phát triển nhưng không làm tăng vọt đường huyết của mẹ sau khi ăn. Các nguyên tắc dinh dưỡng cơ bản gồm:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>Chia nhỏ bữa ăn:</strong> Chia thành 3 bữa chính và 2 - 3 bữa phụ mỗi ngày. Điều này giúp phân phối lượng carbohydrate đều đặn, tránh đường huyết tăng cao sau bữa ăn chính và giảm nguy cơ hạ đường huyết khi xa bữa ăn.</li>
                            <li><strong>Lựa chọn thực phẩm có chỉ số đường huyết thấp (Low GI):</strong> Thay thế tinh bột hấp thu nhanh (gạo trắng, bánh mì trắng, xôi, nước ngọt) bằng tinh bột hấp thu chậm (gạo lứt, yến mạch, khoai lang luộc, bánh mì đen).</li>
                            <li><strong>Tăng cường chất xơ:</strong> Ăn nhiều rau xanh trong bữa ăn trước khi ăn tinh bột để làm chậm quá trình hấp thu đường vào máu.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Gợi ý thực đơn chuẩn trong ngày cho mẹ bầu</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-3'>
                            <li><strong>Bữa sáng (7:00):</strong> 1 lát bánh mì đen nguyên cám + 1 quả trứng ốp la + 100g salad rau cải xanh trộn dầu ô liu. Tránh uống sữa ngọt vào buổi sáng.</li>
                            <li><strong>Bữa phụ sáng (9:30):</strong> 1 cốc sữa đậu nành không đường (hoặc sữa tươi không đường) + 5-6 hạt hạnh nhân/hạt óc chó.</li>
                            <li><strong>Bữa trưa (12:00):</strong> 1 bát cơm gạo lứt + 150g ức gà áp chảo (hoặc cá thu kho nhạt) + 1 bát canh rau bí + 100g bông cải xanh luộc.</li>
                            <li><strong>Bữa phụ chiều (15:00):</strong> 1/2 quả bơ chín (không đường/sữa đặc) hoặc 1 hũ sữa chua không đường.</li>
                            <li><strong>Bữa tối (18:30):</strong> 1 bát cơm gạo lứt nhỏ + 150g thịt bò xào ớt chuông + 1 bát canh rau đay + 1 miếng đậu hũ luộc.</li>
                            <li><strong>Bữa phụ tối (21:30):</strong> 1 ly sữa tươi không đường ấm để tránh hạ đường huyết ban đêm.</li>
                        </ul>
                        
                        <div class='bg-orange-50 border-l-4 border-orange-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-orange-800'>🚫 Thực phẩm cần kiên quyết tránh:</p>
                            <p class='text-orange-700 text-sm'>Nước ép trái cây ngọt (nên ăn cả bã trái cây thay vì ép nước), bánh kẹo ngọt, mật ong, trái cây sấy khô, chè, kem, các loại hoa quả có lượng đường quá cao như sầu riêng, mít, nhãn, vải chín.</p>
                        </div>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Theo dõi sức khỏe và kiểm tra đường huyết</h4>
                        <p class='mb-4'>Mẹ bầu cần đo đường huyết mao mạch bằng máy đo cá nhân tại nhà theo hướng dẫn của bác sĩ (thường đo 4 lần/ngày: lúc đói buổi sáng và 1 - 2 giờ sau các bữa ăn chính). Kết hợp đi bộ nhẹ nhàng 15 - 20 phút sau khi ăn để tăng hiệu quả tiêu thụ đường của cơ bắp.</p>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Hướng dẫn quốc gia về Dinh dưỡng và Đái tháo đường thai kỳ - Bộ Y tế Việt Nam.</p>
                    "
                },
                new()
                {
                    Id = "tram-cam-sau-sinh-nhan-biet-va-dong-hanh",
                    CategoryName = "Sản phụ khoa",
                    CategoryColor = "#db2777",
                    Title = "Trầm cảm sau sinh: Nhận biết dấu hiệu và cách đồng hành cùng người mẹ",
                    Description = "Trầm cảm sau sinh là hội chứng tâm lý phổ biến ảnh hưởng sâu sắc đến sức khỏe bà mẹ và sự phát triển của trẻ. Việc nhận biết sớm giúp phòng tránh những hậu quả đáng tiếc.",
                    ImageUrl = "https://images.unsplash.com/photo-1491013516836-7db643ee125a?q=80&w=800",
                    DateString = "25 Tháng 4, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Trầm cảm sau sinh là một vấn đề sức khỏe tâm lý phổ biến nhưng thường bị xem nhẹ tại Việt Nam. Theo thống kê y tế, có khoảng 10-20% phụ nữ gặp phải tình trạng này sau khi sinh con. Bệnh viện Phụ sản Từ Dũ và Viện Sức khỏe Tâm thần Quốc gia khuyến cáo người thân cần nâng cao nhận thức để đồng hành và cứu giúp người mẹ kịp thời.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Phân biệt giữa 'Baby Blues' và Trầm cảm sau sinh</h4>
                        <p class='mb-3'>Rất nhiều người nhầm lẫn hai trạng thái này, dẫn tới việc chủ quan bỏ qua giai đoạn vàng điều trị:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>Baby Blues:</strong> Cảm giác buồn bã, lo âu, dễ khóc xuất hiện ở khoảng 80% sản phụ. Trạng thái này thường tự biến mất sau 10 - 14 ngày khi cơ thể thích nghi với sự thay đổi nội tiết tố và nhịp sinh hoạt mới.</li>
                            <li><strong>Trầm cảm sau sinh (Postpartum Depression):</strong> Các triệu chứng buồn bã, mất ngủ, kiệt sức diễn ra dữ dội hơn và kéo dài trên 2 tuần, thậm chí nhiều tháng sau sinh, cản trở trực tiếp khả năng chăm sóc bản thân và em bé.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Dấu hiệu nhận biết trầm cảm sau sinh ở người mẹ</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li>Luôn có cảm giác buồn bã, trống rỗng, khóc lóc vô cớ.</li>
                            <li>Mất ngủ kéo dài dù em bé đã ngủ say, hoặc ngược lại ngủ quá nhiều nhưng vẫn thấy kiệt sức.</li>
                            <li>Lo âu tột độ về sức khỏe của con hoặc thờ ơ, không cảm thấy gắn kết tình cảm với con.</li>
                            <li>Dễ nổi giận, cáu gắt với chồng và những người xung quanh.</li>
                            <li>Xuất hiện ý nghĩ làm tổn thương bản thân hoặc làm tổn thương em bé.</li>
                        </ul>
                        
                        <div class='bg-pink-50 border-l-4 border-pink-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-pink-800'>💡 Vai trò cực kỳ quan trọng của gia đình:</p>
                            <p class='text-pink-700 text-sm'>Trầm cảm sau sinh không phải là sự 'làm nũng' hay 'yếu đuối' của người mẹ. Đây là một bệnh lý thực sự do sự suy giảm đột ngột hormone Estrogen và Progesterone kết hợp với áp lực chăm con. Sự quan tâm chia sẻ việc nhà, chăm bé từ người chồng là liều thuốc tinh thần tốt nhất.</p>
                        </div>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Cách can thiệp và điều trị</h4>
                        <p class='mb-4'>Khi có các dấu hiệu trầm cảm nhẹ đến vừa, người mẹ cần được tư vấn tâm lý liệu pháp. Trong các trường hợp nặng, bác sĩ chuyên khoa tâm thần có thể kê đơn các nhóm thuốc chống trầm cảm an toàn cho phụ nữ cho con bú. Tuyệt đối không tự ý chịu đựng hoặc tự mua thuốc uống.</p>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Hướng dẫn chăm sóc sức khỏe tâm thần sản phụ - Bộ Y tế Việt Nam.</p>
                    "
                },
                new()
                {
                    Id = "benh-sot-xuat-huyet-o-tre-em-huong-dan-cham-soc",
                    CategoryName = "Nhi khoa",
                    CategoryColor = "#0284c7",
                    Title = "Sốt xuất huyết ở trẻ em: Dấu hiệu nguy hiểm và cách chăm sóc an toàn",
                    Description = "Sốt xuất huyết Dengue ở trẻ nhỏ dễ chuyển nặng nhanh chóng. Phụ huynh cần biết cách hạ sốt đúng, theo dõi các dấu hiệu cảnh báo để nhập viện kịp thời.",
                    ImageUrl = "/images/dengue.png",
                    DateString = "22 Tháng 4, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Sốt xuất huyết Dengue là bệnh truyền nhiễm cấp tính do virus Dengue gây ra qua muỗi vằn truyền bệnh. Tại Việt Nam, dịch sốt xuất huyết bùng phát mạnh vào mùa mưa. Trẻ em là đối tượng dễ gặp biến chứng nặng nhất nếu không được phát hiện và xử trí đúng cách.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Ba giai đoạn phát triển của bệnh sốt xuất huyết ở trẻ</h4>
                        <ul class='list-decimal pl-5 mb-4 space-y-2'>
                            <li><strong>Giai đoạn sốt (Ngày 1 - 3):</strong> Trẻ sốt cao đột ngột, liên tục 39 - 40 độ C, khó hạ sốt bằng thuốc thông thường. Trẻ có kèm nhức đầu, chán ăn, buồn nôn, đau cơ xương khớp và có thể có chấm xuất huyết dưới da.</li>
                            <li><strong>Giai đoạn nguy hiểm (Ngày 4 - 7):</strong> Lúc này trẻ có thể đã giảm sốt hoặc hết sốt hẳn. Tuy nhiên, đây mới là giai đoạn nguy hiểm nhất vì có thể xảy ra tình trạng thoát huyết tương gây cô đặc máu, tràn dịch màng phổi, tràn dịch màng bụng và giảm tiểu cầu nghiêm trọng dẫn tới xuất huyết nội tạng.</li>
                            <li><strong>Giai đoạn hồi phục (Ngày 8 trở đi):</strong> Trẻ hết sốt, tổng trạng tốt lên, thèm ăn trở lại, nhịp tim ổn định và các vết ban đỏ bắt đầu bay dần kèm ngứa nhẹ trên da.</li>
                        </ul>
                        
                        <div class='bg-amber-50 border-l-4 border-amber-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-amber-800'>⚠️ Dấu hiệu cảnh báo nguy hiểm cần nhập viện cấp cứu ngay:</p>
                            <ul class='list-disc pl-5 text-amber-700 text-sm space-y-1'>
                                <li>Trẻ lờ đờ, ngủ li bì hoặc quấy khóc vật vã.</li>
                                <li>Đau bụng dữ dội, đặc biệt là đau ở vùng hạ sườn phải (vùng gan).</li>
                                <li>Nôn ói nhiều (nôn từ 3 lần trở lên trong vòng 1 giờ hoặc 4 lần trong 6 giờ).</li>
                                <li>Chảy máu chân răng, chảy máu cam hoặc đi tiểu ra máu, đi ngoài phân đen.</li>
                                <li>Tay chân lạnh, ẩm, da nổi vân tím.</li>
                            </ul>
                        </div>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Hướng dẫn chăm sóc trẻ sốt xuất huyết tại nhà</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>Hạ sốt an toàn:</strong> Chỉ dùng Paracetamol đơn chất liều 10 - 15 mg/kg mỗi 4 - 6 giờ. Tuyệt đối KHÔNG dùng Ibuprofen hay Aspirin vì hai loại này làm trầm trọng thêm tình trạng chảy máu và gây suy gan cấp.</li>
                            <li><strong>Bù nước liên tục:</strong> Cho trẻ uống nhiều dung dịch Oresol pha đúng tỷ lệ, nước trái cây (như nước dừa, nước cam) hoặc sữa. Bù nước bằng đường uống là chìa khóa vàng giúp hạn chế truyền dịch.</li>
                            <li><strong>Theo dõi sát sao:</strong> Cho trẻ nằm nghỉ ngơi tại giường, tránh chạy nhảy vận động mạnh gây va đập chảy máu.</li>
                        </ul>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Phác đồ điều trị Sốt xuất huyết Dengue ở trẻ em - Bệnh viện Nhi Đồng 1.</p>
                    "
                },
                new()
                {
                    Id = "lich-tiem-chung-mo-rong-cho-tre-em",
                    CategoryName = "Nhi khoa",
                    CategoryColor = "#0284c7",
                    Title = "Lịch tiêm chủng đầy đủ cho trẻ từ 0 - 2 tuổi bố mẹ cần ghi nhớ",
                    Description = "Cập nhật lịch tiêm phòng chi tiết và đầy đủ nhất giúp trẻ phòng ngừa các bệnh truyền nhiễm nguy hiểm như phế cầu, viêm não Nhật Bản, cúm và 6 trong 1.",
                    ImageUrl = "https://images.unsplash.com/photo-1573883431205-98b5f10aaedb?q=80&w=800",
                    DateString = "18 Tháng 4, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Tiêm chủng phòng bệnh là phương pháp phòng ngừa hiệu quả nhất bảo vệ trẻ em trước hơn 20 căn bệnh truyền nhiễm nguy hiểm. Việc tuân thủ đúng lịch trình giúp trẻ xây dựng hệ miễn dịch vững chắc ngay từ những tháng đầu đời. Dưới đây là tổng hợp lịch tiêm chủng đầy đủ nhất theo Chương trình Tiêm chủng mở rộng quốc gia và tiêm chủng dịch vụ tại Việt Nam.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Giai đoạn sơ sinh (Tháng đầu tiên sau sinh)</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li><strong>Vắc xin Lao (BCG):</strong> Tiêm càng sớm càng tốt trong vòng 30 ngày đầu sau sinh.</li>
                            <li><strong>Vắc xin Viêm gan B (mũi sơ sinh):</strong> Tiêm trong vòng 24 giờ đầu sau sinh để phòng lây truyền từ mẹ sang con.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Giai đoạn từ 2 đến 6 tháng tuổi</h4>
                        <table class='w-full border-collapse my-4 text-sm'>
                            <thead>
                                <tr class='bg-gray-100 text-left'>
                                    <th class='border p-2 font-bold'>Độ tuổi</th>
                                    <th class='border p-2 font-bold'>Loại vắc xin cần tiêm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class='border p-2 font-semibold'>2 tháng tuổi</td>
                                    <td class='border p-2'>Mũi 1 vắc xin 6 trong 1 (hoặc 5 trong 1), Uống vắc xin Rota phòng tiêu chảy cấp (Mũi 1), Tiêm vắc xin phòng Phế cầu khuẩn (Phế cầu 10 hoặc 13 - Mũi 1).</td>
                                </tr>
                                <tr>
                                    <td class='border p-2 font-semibold'>3 tháng tuổi</td>
                                    <td class='border p-2'>Mũi 2 vắc xin 6 trong 1 (hoặc 5 trong 1), Uống vắc xin Rota (Mũi 2).</td>
                                </tr>
                                <tr>
                                    <td class='border p-2 font-semibold'>4 tháng tuổi</td>
                                    <td class='border p-2'>Mũi 3 vắc xin 6 trong 1 (hoặc 5 trong 1), Uống vắc xin Rota (Mũi 3 - tùy loại), Tiêm vắc xin phòng Phế cầu khuẩn (Mũi 2).</td>
                                </tr>
                                <tr>
                                    <td class='border p-2 font-semibold'>6 tháng tuổi</td>
                                    <td class='border p-2'>Tiêm vắc xin phòng Cúm (Mũi 1, mũi 2 tiêm sau mũi 1 một tháng), Tiêm vắc xin Não mô cầu B (Mũi 1), Tiêm vắc xin phòng Phế cầu khuẩn (Mũi 3).</td>
                                </tr>
                            </tbody>
                        </table>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>3. Giai đoạn từ 9 đến 24 tháng tuổi</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>9 tháng tuổi:</strong> Tiêm vắc xin Sởi đơn hoặc vắc xin Sởi - Quai bị - Rubella (MMR Mũi 1), Tiêm vắc xin Viêm não Nhật Bản (mũi dịch vụ), Tiêm vắc xin phòng bệnh Thủy đậu (Mũi 1).</li>
                            <li><strong>12 tháng tuổi:</strong> Tiêm vắc xin phòng Viêm gan A (Mũi 1), Tiêm vắc xin phòng viêm màng não do phế cầu (nhắc lại).</li>
                            <li><strong>18 - 24 tháng tuổi:</strong> Tiêm mũi nhắc lại (Mũi 4) vắc xin 6 trong 1 (hoặc 5 trong 1), Tiêm nhắc lại vắc xin Sởi - Quai bị - Rubella.</li>
                        </ul>
                        
                        <div class='bg-[#eff6ff] border-l-4 border-blue-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-blue-800'>💡 Lưu ý quan trọng cho cha mẹ khi đưa trẻ đi tiêm:</p>
                            <p class='text-blue-700 text-sm'>Luôn theo dõi trẻ ít nhất 30 phút tại điểm tiêm chủng để kịp thời phát hiện các phản ứng dị ứng phản vệ nặng. Tiếp tục theo dõi thân nhiệt, nhịp thở và vết tiêm của trẻ tại nhà trong vòng 24 - 48 giờ sau đó.</p>
                        </div>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Chương trình Tiêm chủng mở rộng Quốc gia - Bộ Y tế Việt Nam.</p>
                    "
                },
                new()
                {
                    Id = "dinh-duong-phu-nu-tien-man-kinh",
                    CategoryName = "Dinh dưỡng",
                    CategoryColor = "#d97706",
                    Title = "Chế độ dinh dưỡng khoa học nâng cao sức khỏe phụ nữ tiền mãn kinh",
                    Description = "Thời kỳ tiền mãn kinh gây ra nhiều xáo trộn về sinh lý và tâm lý ở phụ nữ. Thực đơn giàu phytoestrogen, canxi và lối sống lành mạnh giúp cải thiện chất lượng sống.",
                    ImageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?q=80&w=800",
                    DateString = "15 Tháng 4, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Tiền mãn kinh là giai đoạn chuyển đổi tự nhiên trước khi người phụ nữ bước sang thời kỳ mãn kinh hoàn toàn, thường bắt đầu từ tuổi 40 - 45. Sự suy giảm hormone Estrogen gây ra hàng loạt xáo trộn sinh lý như bốc hỏa, mất ngủ, nguy cơ loãng xương và các bệnh lý tim mạch. Xây dựng một chế độ ăn uống khoa học là chìa khóa vàng giúp phụ nữ vượt qua giai đoạn này một cách nhẹ nhàng.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Những dưỡng chất thiết yếu cần bổ sung ở tuổi tiền mãn kinh</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-2'>
                            <li><strong>Canxi và Vitamin D3 phòng chống loãng xương:</strong> Phụ nữ tiền mãn kinh cần khoảng 1000 - 1200mg Canxi mỗi ngày. Nguồn canxi tốt nhất đến từ sữa không đường, sữa chua, phô mai, cá nguyên xương, và các loại rau có màu xanh đậm.</li>
                            <li><strong>Phytoestrogens (Estrogen thực vật):</strong> Các hợp chất tự nhiên có cấu trúc tương tự Estrogen trong cơ thể, giúp cân bằng nội tiết tố và giảm các cơn bốc hỏa. Đậu nành, hạt lanh, hạt mè, quả mọng và các loại đậu là nguồn dồi dào phytoestrogen.</li>
                            <li><strong>Chất xơ và Axit béo Omega-3:</strong> Giúp kiểm soát cân nặng, giảm lượng cholesterol xấu trong máu để ngăn ngừa nguy cơ xơ vữa động mạch và đột quỵ ở độ tuổi trung niên. Nên bổ sung từ các loại cá béo (cá hồi, cá trích, cá thu) và các loại hạt (hạnh nhân, óc chó).</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Thiết lập lối sống năng động và lành mạnh</h4>
                        <p class='mb-3'>Bên cạnh dinh dưỡng, tập luyện thể thao thường xuyên đóng vai trò vô cùng quan trọng:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li>Tập các bài tập kháng lực nhẹ như đi bộ nhanh, yoga, thiền định giúp giảm căng thẳng và bảo vệ mật độ xương.</li>
                            <li>Ngủ đủ 7 - 8 tiếng mỗi ngày để điều hòa nhịp tim và hệ thần kinh thực vật.</li>
                            <li>Hạn chế tối đa các chất kích thích như caffeine, rượu bia, thức ăn nhiều gia vị cay nóng vào buổi tối để hạn chế đổ mồ hôi trộm và bốc hỏa.</li>
                        </ul>
                        
                        <div class='bg-orange-50 border-l-4 border-orange-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-orange-800'>⚠️ Cảnh báo tự ý bổ sung nội tiết tố từ thực phẩm chức năng:</p>
                            <p class='text-orange-700 text-sm'>Tuyệt đối không tự ý mua các viên uống bổ sung hormone Estrogen liều cao khi chưa có chỉ định của bác sĩ chuyên khoa sản. Việc lạm dụng hormone thay thế kéo dài có thể làm tăng nguy cơ mắc các bệnh lý nguy hiểm như u xơ tử cung, u vú hoặc huyết khối tĩnh mạch.</p>
                        </div>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Khuyến nghị dinh dưỡng cho phụ nữ trung niên - Viện Dinh dưỡng Quốc gia.</p>
                    "
                },
                new()
                {
                    Id = "viem-nhiem-phu-khoa-thuong-gap-cach-phong-ngua",
                    CategoryName = "Phụ sản",
                    CategoryColor = "#7c3aed",
                    Title = "Các bệnh viêm nhiễm phụ khoa thường gặp: Nhận diện và phòng ngừa",
                    Description = "Viêm nhiễm phụ khoa là nỗi lo lắng thầm kín của hầu hết phụ nữ. Hiểu rõ nguyên nhân và cách vệ sinh đúng cách giúp bảo vệ sức khỏe sinh sản lâu dài.",
                    ImageUrl = "https://images.unsplash.com/photo-1581594693702-fbdc51b2763b?q=80&w=800",
                    DateString = "12 Tháng 4, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Viêm nhiễm phụ khoa là tình trạng viêm âm đạo, âm hộ, cổ tử cung do sự mất cân bằng của hệ vi sinh vật hoặc do sự tấn công từ bên ngoài của nấm, vi khuẩn, ký sinh trùng. Theo khảo sát y tế tại Việt Nam, có đến hơn 90% phụ nữ từng mắc viêm phụ khoa ít nhất một lần trong đời. Bệnh tuy không đe dọa trực tiếp tính mạng nhưng nếu để mạn tính có thể gây tắc vòi trứng, vô sinh hoặc biến chứng trong thai kỳ.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Ba bệnh viêm phụ khoa phổ biến nhất và dấu hiệu nhận biết</h4>
                        <ul class='list-disc pl-5 mb-4 space-y-3'>
                            <li><strong>Viêm âm đạo do nấm Candida:</strong> Dấu hiệu đặc trưng nhất là ngứa ngáy vùng kín dữ dội, khí hư (huyết trắng) ra nhiều, màu trắng đục, vón cục như bã đậu hoặc sữa chua, không có mùi hôi tanh nhưng gây đau rát khi quan hệ hoặc đi tiểu.</li>
                            <li><strong>Viêm âm đạo do tạp khuẩn (Bacterial Vaginosis):</strong> Do sự suy giảm lợi khuẩn Lactobacillus tạo điều kiện cho vi khuẩn kị khí phát triển. Khí hư ra nhiều, màu trắng xám hoặc hơi vàng, loãng, có mùi tanh nồng đặc trưng (nhất là sau khi quan hệ tình dục).</li>
                            <li><strong>Viêm âm đạo do ký sinh trùng Trichomonas:</strong> Lây nhiễm chủ yếu qua quan hệ tình dục không an toàn. Khí hư ra nhiều, màu xanh hoặc vàng nhạt, loãng, có bọt, kèm theo mùi hôi và cảm giác ngứa ngáy âm hộ dữ dội.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Hướng dẫn vệ sinh vùng kín đúng cách chuẩn y khoa</h4>
                        <ul class='list-decimal pl-5 mb-4 space-y-2'>
                            <li><strong>Không thụt rửa sâu vào trong âm đạo:</strong> Âm đạo có cơ chế tự làm sạch tự nhiên và duy trì độ pH axit nhẹ (3.8 - 4.5). Thụt rửa sâu sẽ tiêu diệt lợi khuẩn, làm thay đổi pH và đẩy vi khuẩn từ ngoài vào sâu bên trong gây viêm tử cung, phần phụ.</li>
                            <li><strong>Lựa chọn dung dịch vệ sinh phù hợp:</strong> Nên chọn các loại có độ pH phù hợp (pH 4 - 4.5), không chứa chất tạo bọt mạnh, không mùi hương quá nồng. Chỉ rửa nhẹ nhàng bên ngoài âm hộ 1 - 2 lần mỗi ngày.</li>
                            <li><strong>Giữ vùng kín luôn khô thoáng:</strong> Sử dụng quần lót bằng chất liệu cotton co giãn, thấm hút mồ hôi tốt. Thay quần lót hàng ngày và giặt phơi dưới ánh nắng mặt trời trực tiếp.</li>
                        </ul>
                        
                        <div class='bg-purple-50 border-l-4 border-purple-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-purple-800'>💡 Khuyên dùng từ chuyên gia sản khoa:</p>
                            <p class='text-purple-700 text-sm'>Khi xuất hiện khí hư bất thường, chị em nên đến cơ sở chuyên khoa để khám và soi tươi dịch âm đạo để điều trị đúng căn nguyên. Tuyệt đối không tự ý mua thuốc đặt âm đạo theo mách bảo, tránh tình trạng kháng thuốc và làm bệnh chuyển biến phức tạp hơn.</p>
                        </div>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Hướng dẫn điều trị các bệnh lý phụ khoa - Bệnh viện Phụ sản Trung ương.</p>
                    "
                },
                new()
                {
                    Id = "tao-bon-o-tre-em-giai-phap-dinh-duong-thoi-quen",
                    CategoryName = "Dinh dưỡng",
                    CategoryColor = "#d97706",
                    Title = "Giải pháp dứt điểm tình trạng táo bón ở trẻ từ thói quen đến dinh dưỡng",
                    Description = "Táo bón kéo dài ở trẻ nhỏ gây biếng ăn, chậm lớn và nứt hậu môn. Hướng dẫn bổ sung chất xơ hòa tan, men vi sinh và cách tập phản xạ đi tiêu đúng giờ cho trẻ.",
                    ImageUrl = "https://images.unsplash.com/photo-1464965911861-746a04b4bca6?q=80&w=800",
                    DateString = "08 Tháng 4, 2026",
                    Content = @"
                        <p class='mb-4 font-semibold text-gray-700'>Táo bón là tình trạng giảm tần suất đi tiêu bình thường (dưới 3 lần/tuần) kèm theo đi tiêu khó khăn, phân khô, cứng hoặc có kích thước lớn khiến trẻ đau đớn, quấy khóc. Đây là rối loạn tiêu hóa thường gặp nhất ở trẻ nhỏ, chiếm đến 25% các trường hợp đến khám tại chuyên khoa Tiêu hóa Nhi khoa. Điều trị táo bón cần sự kiên trì từ cha mẹ trong việc thay đổi chế độ dinh dưỡng và thói quen sinh hoạt của bé.</p>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>1. Nguyên nhân hàng đầu gây táo bón ở trẻ</h4>
                        <p class='mb-3'>Đa phần táo bón ở trẻ là táo bón chức năng (hơn 95%), bắt nguồn từ các nguyên nhân:</p>
                        <ul class='list-disc pl-5 mb-4 space-y-1'>
                            <li><strong>Nhịn đi tiêu do sợ đau:</strong> Khi có một lần đi tiêu đau do phân cứng, trẻ sẽ nảy sinh tâm lý sợ hãi, cố nhịn đi tiêu bằng cách thắt chặt cơ hậu môn. Phân tích tụ lâu ngày trong đại tràng sẽ bị hấp thụ bớt nước, ngày càng to và cứng hơn, tạo thành một vòng xoắn bệnh lý nguy hại.</li>
                            <li><strong>Chế độ ăn thiếu chất xơ và uống ít nước:</strong> Trẻ lười ăn rau xanh, trái cây nhưng lại uống nhiều sữa bò, ăn đồ ngọt, thức ăn nhanh.</li>
                            <li><strong>Thay đổi môi trường sống:</strong> Trẻ bắt đầu đi học mẫu giáo, ngại đi vệ sinh tại trường do nhà vệ sinh không quen thuộc hoặc không sạch sẽ.</li>
                        </ul>
                        
                        <h4 class='text-lg font-bold text-primary mt-6 mb-3'>2. Giải pháp dứt điểm táo bón từ gốc</h4>
                        <ul class='list-decimal pl-5 mb-4 space-y-2'>
                            <li><strong>Tăng cường chất xơ hòa tan trong khẩu phần ăn:</strong> Cho trẻ ăn các loại rau củ nhuận tràng tốt như rau mồng tơi, rau khoai lang, đu đủ chín, chuối tiêu, lê, mận và ngũ cốc nguyên hạt. Bổ sung các loại quả có hàm lượng pectin và sorbitol cao để làm mềm phân tự nhiên.</li>
                            <li><strong>Uống đủ nước:</strong> Đảm bảo lượng nước uống hàng ngày cho trẻ (bao gồm nước lọc, nước canh, nước trái cây tươi). Lượng nước cần thiết thay đổi theo độ tuổi và cân nặng của trẻ.</li>
                            <li><strong>Tập thói quen đi tiêu đúng giờ:</strong> Hướng dẫn trẻ ngồi bô/bồn cầu khoảng 5 - 10 phút sau bữa ăn chính (thường là sau bữa sáng hoặc bữa tối) để tận dụng phản xạ dạ dày - ruột. Kê thêm một chiếc ghế nhỏ dưới chân trẻ khi ngồi bồn cầu để tạo tư thế ngồi xổm tự nhiên giúp đi tiêu dễ dàng hơn.</li>
                        </ul>
                        
                        <div class='bg-amber-50 border-l-4 border-amber-500 p-4 rounded-r-lg my-6'>
                            <p class='font-bold text-amber-800'>⚠️ Thận trọng khi sử dụng thuốc bơm thụt hậu môn:</p>
                            <p class='text-amber-700 text-sm'>Tuyệt đối không lạm dụng các loại thuốc bơm thụt hậu môn cho trẻ thường xuyên. Việc bơm thụt liên tục sẽ làm mất phản xạ đi tiêu tự nhiên của trực tràng, gây tổn thương niêm mạc hậu môn và làm trẻ càng thêm sợ hãi việc đi tiêu.</p>
                        </div>
                        
                        <p class='mt-6 text-sm text-gray-500 italic'>Nguồn tham khảo: Hướng dẫn chẩn đoán và xử trí táo bón chức năng ở trẻ em - Hội Nhi khoa Việt Nam.</p>
                    "
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WebDKLichKham.Models.ViewModels;

namespace WebDKLichKham.Data
{
    public static class MedicalKnowledgeRepository
    {
        private static readonly List<SymptomCategory> _categories = new()
        {
            new() { Id = "neuro", Name = "Nội Thần kinh", Icon = "psychology" },
            new() { Id = "respiratory", Name = "Nội Hô hấp", Icon = "pulmonology" },
            new() { Id = "digestive", Name = "Nội Tiêu hóa", Icon = "gastroenterology" },
            new() { Id = "cardio", Name = "Nội Tim mạch", Icon = "cardiology" },
            new() { Id = "endocrine", Name = "Nội tiết & Chuyển hóa", Icon = "bloodtype" }
        };

        private static readonly List<SymptomDetail> _diseases = new()
        {
            // ==================== NỘI THẦN KINH ====================
            new()
            {
                Id = "dot-quy-nao",
                CategoryId = "neuro",
                CategoryName = "Nội Thần kinh",
                Name = "Đột quỵ não (Tai biến mạch máu não)",
                ShortDescription = "Nguyên nhân tử vong và tàn phế hàng đầu tại Việt Nam. Nhận biết sớm và cấp cứu trong giờ vàng là yếu tố sống còn.",
                Overview = "Đột quỵ não xảy ra khi nguồn cung cấp máu cho một phần của não bị suy giảm hoặc mất hoàn toàn, làm cho tế bào não thiếu oxy và dinh dưỡng trầm trọng. Trong vòng vài phút, các tế bào não sẽ bắt đầu chết hàng loạt. Đột quỵ được chia thành hai thể lâm sàng chính: Nhồi máu não (do tắc nghẽn mạch máu, chiếm 85% số ca) và Xuất huyết não (do vỡ mạch máu não).",
                Symptoms = new List<string>
                {
                    "Méo miệng, lệch nhân trung, nụ cười không cân xứng, tê cứng nửa bên mặt.",
                    "Yếu liệt hoặc tê bì đột ngột ở một tay và một chân cùng bên cơ thể, khó nhấc tay hoặc bước đi.",
                    "Nói ngọng, nói lắp đột ngột, khó tìm từ diễn đạt hoặc không hiểu lời nói của người khác.",
                    "Mờ mắt, nhòe mắt hoặc mất thị lực một bên mắt đột ngột.",
                    "Đau đầu dữ dội cấp tính mà không rõ nguyên nhân, kèm theo chóng mặt, mất thăng bằng hoặc nôn mửa."
                },
                Causes = new List<string>
                {
                    "Tăng huyết áp: Tạo áp lực lớn lên thành mạch máu, dẫn đến xơ vữa hoặc nứt vỡ mạch.",
                    "Đái tháo đường: Làm tổn thương lòng mạch và đẩy nhanh quá trình hình thành mảng xơ vữa.",
                    "Rối loạn lipid máu: Tăng Cholesterol xấu tạo mảng bám gây hẹp và tắc nghẽn động mạch.",
                    "Bệnh lý tim mạch: Rung nhĩ, hẹp hở van tim tạo cục máu đông di chuyển lên gây tắc mạch não.",
                    "Lối sống thiếu khoa học: Hút thuốc lá, lạm dụng rượu bia, béo phì và lười vận động."
                },
                Impacts = new List<string>
                {
                    "Liệt nửa người hoặc liệt tứ chi, gây khó khăn lớn trong sinh hoạt hàng ngày.",
                    "Rối loạn ngôn ngữ và giao tiếp (thất ngôn Broca hoặc Wernicke).",
                    "Suy giảm nhận thức, sa sút trí tuệ do mạch máu.",
                    "Rối loạn nuốt, dễ gây sặc dẫn đến viêm phổi do hít.",
                    "Trầm cảm và rối loạn lo âu sau đột quỵ."
                },
                Treatments = new List<string>
                {
                    "Sử dụng thuốc tiêu sợi huyết (rtPA) đường tĩnh mạch trong 'giờ vàng' (dưới 4.5 giờ đầu từ khi khởi phát triệu chứng) đối với thể nhồi máu não.",
                    "Can thiệp lấy huyết khối bằng dụng cụ cơ học (Stent kéo huyết khối) đối với tắc mạch lớn trong vòng 6 giờ đầu.",
                    "Phẫu thuật mở hộp sọ giảm áp đối với trường hợp xuất huyết não diện rộng hoặc nhồi máu não lớn gây phù não nặng.",
                    "Kiểm soát tối ưu huyết áp, đường huyết, mỡ máu và sử dụng thuốc kháng tiểu cầu (Aspirin, Clopidogrel) lâu dài để dự phòng tái phát.",
                    "Tập vật lý trị liệu và phục hồi chức năng sớm ngay tại giường bệnh từ ngày thứ 2 để giảm thiểu tàn phế."
                },
                Prevention = "Kiểm soát chặt chẽ chỉ số huyết áp (< 130/80 mmHg). Điều trị ổn định bệnh tiểu đường, mỡ máu và loạn nhịp tim. Bỏ hoàn toàn thuốc lá và hạn chế bia rượu. Thực hiện chế độ ăn nhạt (giảm muối), tăng cường chất xơ từ rau xanh và trái cây. Duy trì tập thể thao trung bình 30 phút mỗi ngày.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 5649/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và xử trí đột quỵ não cấp của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Khuyến cáo tất cả cơ sở y tế thiết lập quy trình cấp cứu đột quỵ ưu tiên (Code Stroke) để tối ưu thời gian tiếp cận rtPA.",
                        "Chỉ định chụp cắt lớp vi tính (CT scan) hoặc cộng hưởng từ (MRI) sọ não không cản quang ngay lập tức để loại trừ xuất huyết não trước khi dùng thuốc tiêu sợi huyết.",
                        "Khởi động chương trình phục hồi chức năng vận động và ngôn ngữ đa chuyên khoa càng sớm càng tốt khi huyết động ổn định."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "rtPA in Acute Ischemic Stroke: NINDS Study Group",
                        Journal = "Tạp chí Y học New England (NEJM)",
                        Summary = "Thử nghiệm lâm sàng trên 624 bệnh nhân chứng minh việc điều trị rtPA trong vòng 3 giờ đầu giúp tăng 30% tỷ lệ bệnh nhân phục hồi hoàn toàn hoặc hầu như không để lại di chứng sau 3 tháng."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Cơn thiếu máu não thoáng qua (TIA)", Description = "Triệu chứng đột quỵ tự biến mất trong vòng 24 giờ, là dấu hiệu báo động đỏ cần nhập viện khẩn cấp." },
                    new() { Name = "Hẹp động mạch cảnh", Description = "Tình trạng lắng đọng mảng xơ vữa tại động mạch cảnh ở cổ, gây cản trở máu lên não và dễ bong ra tạo huyết khối gây tắc mạch." }
                },
                Icon = "neurology",
                ImageUrl = "/images/stroke.jpg"
            },
            new()
            {
                Id = "dau-nua-dau",
                CategoryId = "neuro",
                CategoryName = "Nội Thần kinh",
                Name = "Chứng đau nửa đầu (Migraine)",
                ShortDescription = "Cơn đau đầu nhói như búa bổ ở một bên, nhạy cảm với ánh sáng và tiếng động. Gây suy giảm chất lượng sống nghiêm trọng.",
                Overview = "Đau nửa đầu (Migraine) là một bệnh lý thần kinh mạn tính đặc trưng bởi các cơn đau đầu từ trung bình đến dữ dội, thường chỉ xảy ra ở một bên đầu. Cơn đau có tính chất mạch đập (giật nhói theo nhịp mạch) và thường kéo dài từ 4 đến 72 giờ nếu không được điều trị. Bệnh phổ biến hơn ở nữ giới do liên quan đến sự thay đổi nồng độ hormone nội tiết tố nữ.",
                Symptoms = new List<string>
                {
                    "Đau nhói một bên đầu (đôi khi cả hai bên), đau tăng lên khi vận động thể lực.",
                    "Buồn nôn và nôn mửa trong cơn đau đầu.",
                    "Sợ ánh sáng (photophobia) và sợ tiếng động (phonophobia) — người bệnh muốn nằm yên trong phòng tối.",
                    "Triệu chứng báo trước (Aura): Xuất hiện các vệt sáng lấp lánh, điểm mù trước mắt hoặc tê rần một bên mặt trước cơn đau khoảng 20-60 phút."
                },
                Causes = new List<string>
                {
                    "Yếu tố di truyền: Khoảng 70% bệnh nhân có người thân trong gia đình cũng bị Migraine.",
                    "Rối loạn nồng độ Serotonin: Gây co giãn bất thường hệ thống mạch máu não.",
                    "Thay đổi nội tiết tố ở phụ nữ: Cơn đau thường xuất hiện vào chu kỳ kinh nguyệt, thai kỳ hoặc mãn kinh.",
                    "Tác nhân kích thích môi trường: Ánh sáng chói, tiếng ồn lớn, mùi hương nồng, thay đổi thời tiết đột ngột.",
                    "Chế độ ăn uống: Sử dụng thực phẩm chứa Tyramine (phô mai cũ), bột ngọt (mì chính), sô-cô-la, rượu vang đỏ hoặc cafein."
                },
                Impacts = new List<string>
                {
                    "Ảnh hưởng nặng nề đến năng suất học tập và làm việc.",
                    "Rối loạn giấc ngủ và mệt mỏi mạn tính.",
                    "Lạm dụng thuốc giảm đau dẫn đến hội chứng đau đầu do lạm dụng thuốc (Medication Overuse Headache)."
                },
                Treatments = new List<string>
                {
                    "Cắt cơn đau nhẹ đến trung bình: Sử dụng thuốc giảm đau NSAIDs (Ibuprofen, Naproxen) hoặc Paracetamol kết hợp Cafein.",
                    "Cắt cơn đau trung bình đến nặng: Dùng nhóm thuốc chuyên biệt Triptans (Sumatriptan, Zolmitriptan) co mạch máu não.",
                    "Điều trị dự phòng (áp dụng khi bị ≥ 2 cơn/tháng): Sử dụng thuốc chẹn beta (Propranolol), thuốc chẹn kênh canxi (Flunarizine) hoặc thuốc chống trầm cảm ba vòng (Amitriptyline) uống hàng ngày.",
                    "Nghỉ ngơi yên tĩnh trong phòng tối và yên tĩnh, chườm lạnh vùng trán."
                },
                Prevention = "Thiết lập nhật ký đau đầu để xác định và tránh các yếu tố kích hoạt cơn đau. Duy trì giờ giấc ngủ đều đặn, tránh thức khuya. Thực hiện chế độ ăn lành mạnh, hạn chế các món ăn kích hoạt cơn đau. Quản lý căng thẳng thông qua thiền định, yoga hoặc đi bộ nhẹ nhàng.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 3123/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị bệnh lý Thần kinh học của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Chẩn đoán chủ yếu dựa trên tiêu chuẩn lâm sàng ICHD-3, hạn chế lạm dụng CT/MRI sọ não trừ khi có dấu hiệu cảnh báo nguy hiểm (cờ đỏ).",
                        "Khuyến cáo dùng thuốc cắt cơn sớm ngay khi bắt đầu đau đầu; không dùng Triptans cho bệnh nhân có tiền sử bệnh tim thiếu máu cục bộ hoặc đột quỵ.",
                        "Xem xét điều trị dự phòng kéo dài từ 3 đến 6 tháng để giảm tần suất và cường độ cơn đau."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Sumatriptan in Acute Migraine: A Meta-Analysis",
                        Journal = "The Lancet Neurology",
                        Summary = "Phân tích gộp trên hàng ngàn bệnh nhân chứng minh nhóm thuốc Triptans giúp cắt cơn đau hiệu quả trong vòng 2 giờ ở 60-70% người bệnh."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Đau đầu do căng thẳng (Tension Headache)", Description = "Đau ê ẩm như có vòng đai siết chặt quanh đầu, liên quan chặt chẽ đến áp lực tâm lý hoặc mỏi cơ cổ." }
                },
                Icon = "psychology",
                ImageUrl = "/images/migraine.jpg"
            },
            new()
            {
                Id = "roi-loan-tien-dinh",
                CategoryId = "neuro",
                CategoryName = "Nội Thần kinh",
                Name = "Rối loạn chức năng tiền đình",
                ShortDescription = "Cảm giác chóng mặt quay cuồng, mất thăng bằng, ù tai và buồn nôn. Rất phổ biến ở người làm việc văn phòng, căng thẳng kéo dài.",
                Overview = "Rối loạn tiền đình là tình trạng tổn thương hoặc rối loạn hoạt động của bộ phận nhận biết thăng bằng ở tai trong hoặc đường dẫn truyền thần kinh tiền đình ở não bộ. Bệnh khiến cơ thể mất khả năng định hướng không gian, gây chóng mặt dữ dội và cản trở khả năng đứng vững, di chuyển.",
                Symptoms = new List<string>
                {
                    "Chóng mặt quay cuồng: Cảm giác đồ vật xung quanh xoay tròn hoặc bản thân mình bị xoay tròn.",
                    "Mất thăng bằng, đi đứng loạng choạng, dễ ngã khi thay đổi tư thế đột ngột.",
                    "Buồn nôn và nôn mửa nhiều trong cơn chóng mặt cấp.",
                    "Ù tai, giảm thính lực tạm thời hoặc có tiếng vo ve trong tai.",
                    "Khó tập trung, hoa mắt khi nhìn vào các vật chuyển động nhanh."
                },
                Causes = new List<string>
                {
                    "Bệnh thạch nhĩ lạc chỗ (BPPV): Các tinh thể canxi ở tai trong bị bong ra và di chuyển sai vị trí, gây chóng mặt tư thế lành tính.",
                    "Viêm dây thần kinh tiền đình hoặc viêm tai trong do nhiễm virus hoặc vi khuẩn.",
                    "Thiếu máu não: Do hẹp động mạch đốt sống thân nền hoặc thoái hóa cột sống cổ chèn ép mạch máu.",
                    "Stress, căng thẳng tâm lý kéo dài làm suy giảm tuần hoàn hệ thống tiền đình.",
                    "Bệnh Meniere: Tích tụ dịch bất thường ở tai trong."
                },
                Impacts = new List<string>
                {
                    "Nguy cơ té ngã cao dẫn tới chấn thương nghiêm trọng, đặc biệt là ở người cao tuổi.",
                    "Gây tâm lý sợ hãi, lo âu, không dám tự đi lại một mình.",
                    "Giảm tập trung và hiệu suất công việc trí óc."
                },
                Treatments = new List<string>
                {
                    "Trong cơn cấp: Nằm nghỉ trên giường phẳng, nơi yên tĩnh và ít ánh sáng, tránh quay đầu đột ngột.",
                    "Thuốc ức chế tiền đình (ngắn hạn 3-5 ngày): Acetylleucine (Tanganil) hoặc các thuốc kháng histamin (Cinnarizine, Betahistine) giúp giảm chóng mặt.",
                    "Thực hiện các nghiệm pháp tái định vị sỏi tai trong (như nghiệm pháp Epley) đối với bệnh BPPV.",
                    "Tập luyện các bài tập phục hồi chức năng tiền đình (Vestibular Rehabilitation Therapy - VRT) để não bộ thích nghi lại."
                },
                Prevention = "Tránh thay đổi tư thế đột ngột (không bật dậy nhanh khi đang nằm). Tập các bài tập vận động cổ và đầu nhẹ nhàng hàng ngày. Ngủ đủ giấc, tránh thức khuya và quản lý tốt stress. Uống đủ nước, tránh để cơ thể mất nước.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 3123/QĐ-BYT",
                    Title = "Hướng dẫn điều trị chóng mặt do rối loạn tiền đình ngoại biên",
                    Recommendations = new List<string>
                    {
                        "Khuyến cáo thực hiện nghiệm pháp Dix-Hallpike để chẩn đoán phân biệt chóng mặt kịch phát lành tính tư thế (BPPV).",
                        "Không lạm dụng các thuốc kháng cholinergic và an thần kéo dài vì làm chậm quá trình bù trừ tiền đình tự nhiên của não bộ.",
                        "Khuyến khích áp dụng các bài tập phục hồi chức năng tiền đình sớm thay vì nằm bất động lâu ngày."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Efficacy of Epley Maneuver in BPPV: A Randomized Control Trial",
                        Journal = "Journal of Neurology",
                        Summary = "Nghiên cứu chỉ ra rằng nghiệm pháp Epley giúp giải quyết hoàn toàn triệu chứng chóng mặt tư thế ở 85% bệnh nhân ngay trong lần thực hiện đầu tiên."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Thiểu năng tuần hoàn não", Description = "Tình trạng giảm lưu lượng máu đến não gây đau đầu, chóng mặt, suy giáp hoặc suy giảm trí nhớ lâm sàng." }
                },
                Icon = "balance",
                ImageUrl = "/images/vertigo.jpg"
            },

            // ==================== NỘI HÔ HẤP ====================
            new()
            {
                Id = "hen-phe-quan",
                CategoryId = "respiratory",
                CategoryName = "Nội Hô hấp",
                Name = "Hen phế quản (Asthma)",
                ShortDescription = "Tình trạng viêm đường thở mạn tính gây co thắt phế quản phế nang, dẫn tới các cơn khó thở, cò cử kịch phát.",
                Overview = "Hen phế quản (hen suyễn) là một bệnh lý viêm mạn tính của đường thở. Tình trạng viêm này làm cho đường thở trở nên nhạy cảm quá mức với các tác nhân kích thích khác nhau, dẫn đến co thắt phế quản, phù nề niêm mạc phế quản và tăng tiết đờm nhầy gây tắc nghẽn đường thở có thể hồi phục được.",
                Symptoms = new List<string>
                {
                    "Khó thở kịch phát: Cơn khó thở xuất hiện chủ yếu về đêm hoặc khi thay đổi thời tiết, khi gắng sức.",
                    "Thở khò khè, cò cử: Tiếng rít phế quản nghe rõ khi bệnh nhân thở ra.",
                    "Ho khan dai dẳng: Ho kéo dài, đặc biệt nặng hơn vào ban đêm hoặc sáng sớm.",
                    "Cảm giác nặng ngực, bó chặt lồng ngực như có đá đè."
                },
                Causes = new List<string>
                {
                    "Cơ địa dị ứng (Atopy): Người bệnh thường kèm theo viêm mũi dị ứng, chàm da hoặc viêm da cơ địa.",
                    "Yếu tố di truyền: Có cha mẹ bị hen làm tăng nguy cơ mắc bệnh gấp 3-4 lần.",
                    "Tiếp xúc dị nguyên: Bụi nhà, lông chó mèo, phấn hoa, nấm mốc, khói thuốc lá.",
                    "Nhiễm trùng đường hô hấp: Cúm, cảm lạnh làm khởi phát cơn hen cấp.",
                    "Gắng sức hoặc hít phải không khí lạnh khô đột ngột."
                },
                Impacts = new List<string>
                {
                    "Cơn hen phế quản ác tính gây suy hô hấp cấp, đe dọa tính mạng nếu không cắt cơn kịp thời.",
                    "Giới hạn hoạt động thể lực và sinh hoạt hàng ngày.",
                    "Biến dạng lồng ngực và giảm chức năng phổi vĩnh viễn ở bệnh nhân hen mạn tính kiểm soát kém."
                },
                Treatments = new List<string>
                {
                    "Thuốc cắt cơn hen nhanh (SABA): Salbutamol hít/xịt khi xuất hiện cơn khó thở khò khè.",
                    "Thuốc kiểm soát hen hàng ngày (dự phòng): Corticoid dạng hít (ICS - như Budesonide, Fluticasone) đơn trị liệu hoặc phối hợp thuốc giãn phế quản tác dụng kéo dài (LABA - như Salmeterol, Formoterol) để dùng đều đặn hàng ngày.",
                    "Thở oxy và tiêm corticoid tĩnh mạch khi bị cơn hen cấp nặng nhập viện cấp cứu.",
                    "Sử dụng kế hoạch hành động hen để bệnh nhân tự theo dõi bằng lưu lượng đỉnh kế."
                },
                Prevention = "Tránh xa các yếu tố dị nguyên đã được xác định. Giữ ấm đường thở khi thời tiết giao mùa. Tiêm vắc xin phòng cúm hàng năm và phế cầu mỗi 5 năm. Tuyệt đối không tự ý ngưng thuốc dự phòng hen ngay cả khi không còn triệu chứng.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 1851/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị Hen phế quản của Bộ Y tế Việt Nam",
                    Recommendations = new List<string>
                    {
                        "Khuyến cáo thực hiện đo hô hấp ký (Spirometry) với test hồi phục phế quản để chẩn đoán xác định hen phế quản.",
                        "Nhấn mạnh không điều trị hen chỉ bằng thuốc cắt cơn đơn độc (SABA) vì tăng nguy cơ tử vong; bắt buộc phối hợp thuốc dự phòng chứa ICS.",
                        "Đánh giá và điều chỉnh bậc điều trị hen mỗi 1-3 tháng dựa trên mức độ kiểm soát triệu chứng của bệnh nhân."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Global Strategy for Asthma Management and Prevention (GINA 2023)",
                        Journal = "Global Initiative for Asthma",
                        Summary = "Khuyến cáo toàn cầu khẳng định việc sử dụng sớm thuốc dự phòng phối hợp ICS-Formoterol giúp giảm 64% nguy cơ xuất hiện các cơn hen kịch phát nguy kịch so với chỉ dùng Albuterol khi cần."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Viêm mũi dị ứng", Description = "Bệnh lý đồng mắc phổ biến, làm tăng mức độ nặng của hen phế quản nếu không được kiểm soát tốt." }
                },
                Icon = "airway",
                ImageUrl = "/images/asthma.png"
            },
            new()
            {
                Id = "copd",
                CategoryId = "respiratory",
                CategoryName = "Nội Hô hấp",
                Name = "Bệnh phổi tắc nghẽn mạn tính (COPD)",
                ShortDescription = "Bệnh lý tắc nghẽn đường thở tiến triển, không hồi phục hoàn toàn, liên quan mật thiết với khói thuốc lá, thuốc lào.",
                Overview = "Bệnh phổi tắc nghẽn mạn tính (COPD) là một bệnh lý hô hấp phổ biến, đặc trưng bởi các triệu chứng hô hấp dai dẳng và giới hạn luồng khí thở do các bất thường ở đường thở và/hoặc phế nang. Bệnh tiến triển nặng dần theo thời gian và gây suy giảm chức năng hô hấp nghiêm trọng.",
                Symptoms = new List<string>
                {
                    "Khó thở tiến triển: Khó thở tăng dần theo thời gian, ban đầu chỉ khi gắng sức, sau đó khó thở cả khi nghỉ ngơi.",
                    "Ho mạn tính kéo dài: Thường ho khạc đờm vào sáng sớm.",
                    "Khạc đờm nhầy dai dẳng: Đờm thường có màu trắng đục, chuyển sang đờm mủ đục vàng/xanh khi có đợt cấp nhiễm trùng.",
                    "Thở khò khè, lồng ngực hình thùng do bẫy khí trong phổi lâu ngày."
                },
                Causes = new List<string>
                {
                    "Hút thuốc lá, thuốc lào: Chiếm hơn 90% nguyên nhân gây bệnh, bao gồm cả hút thuốc thụ động lâu ngày.",
                    "Ô nhiễm môi trường trong nhà: Đốt sinh khối (củi, than tổ ong) để nấu nướng trong không gian kín.",
                    "Phơi nhiễm nghề nghiệp: Khói bụi hóa chất, bụi than, bụi kim loại tại nơi làm việc.",
                    "Yếu tố di truyền: Thiếu hụt men Alpha-1 antitrypsin (hiếm gặp tại Việt Nam)."
                },
                Impacts = new List<string>
                {
                    "Tàn phế hô hấp, bệnh nhân phải phụ thuộc vào nguồn oxy hỗ trợ tại giường.",
                    "Tâm phế mạn: Suy tim phải do tăng áp lực động mạch phổi.",
                    "Giảm cân, suy kiệt cơ thể do tăng công hô hấp.",
                    "Đợt cấp COPD nhập viện thường xuyên làm tăng tỷ lệ tử vong."
                },
                Treatments = new List<string>
                {
                    "Cai thuốc lá/thuốc lào hoàn toàn (đây là biện pháp duy nhất giúp làm chậm tốc độ suy giảm chức năng phổi).",
                    "Sử dụng các thuốc giãn phế quản dạng hít tác dụng kéo dài: LAMA (Tiotropium) hoặc phối hợp LABA/LAMA.",
                    "Liệu pháp oxy dài hạn tại nhà (≥ 15 giờ/ngày) đối với bệnh nhân suy hô hấp nặng mạn tính.",
                    "Phục hồi chức năng hô hấp: Tập thở cơ hoành, tập ho có kiểm soát và tập thể dục trị liệu phù hợp.",
                    "Dùng kháng sinh, corticoid toàn thân và thông khí nhân tạo khi có đợt cấp COPD."
                },
                Prevention = "Tuyệt đối không hút thuốc lá, thuốc lào và tránh xa khói thuốc. Hạn chế đun nấu bằng than tổ ong, củi trong nhà. Đeo khẩu trang lọc bụi mịn khi làm việc trong môi trường khói bụi. Tiêm phòng vắc xin cúm hàng năm và vắc xin phế cầu đầy đủ.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 5774/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị Bệnh phổi tắc nghẽn mạn tính của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Bắt buộc đo hô hấp ký cho thấy chỉ số FEV1/FVC < 0.70 sau nghiệm pháp giãn phế quản để xác định chẩn đoán COPD.",
                        "Phân nhóm bệnh nhân theo tiêu chí GOLD (A, B, E) để lựa chọn phác đồ thuốc giãn phế quản dạng hít phù hợp.",
                        "Khuyến cáo quản lý bệnh nhân ngoại trú tại các phòng quản lý hen và COPD (ACOCU) để giảm tần suất đợt cấp."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Triple Therapy in COPD: IMPACT Trial",
                        Journal = "The New England Journal of Medicine",
                        Summary = "Nghiên cứu chứng minh liệu pháp hít phối hợp 3 thuốc (ICS/LAMA/LABA) giúp giảm đáng kể tỷ lệ nhập viện vì đợt cấp và giảm 15% tỷ lệ tử vong do mọi nguyên nhân ở bệnh nhân COPD nặng so với liệu pháp 2 thuốc."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Khí phế thũng", Description = "Tình trạng các phế nang bị phá hủy và giãn rộng mất tính đàn hồi, thường là hệ quả của COPD." }
                },
                Icon = "pulmonology",
                ImageUrl = "/images/copd.png"
            },

            // ==================== NỘI TIÊU HÓA ====================
            new()
            {
                Id = "viem-loet-da-day",
                CategoryId = "digestive",
                CategoryName = "Nội Tiêu hóa",
                Name = "Viêm loét dạ dày - tá tràng",
                ShortDescription = "Tổn thương viêm, trợt loét niêm mạc dạ dày hoặc tá tràng do mất cân bằng giữa acid và các yếu tố bảo vệ. Gây đau tức vùng thượng vị.",
                Overview = "Viêm loét dạ dày - tá tràng là bệnh lý tiêu hóa phổ biến hàng đầu. Bệnh xảy ra khi lớp chất nhầy bảo vệ niêm mạc dạ dày bị suy yếu, để cho acid dịch vị tấn công trực tiếp gây viêm, trợt loét sâu. Loét tá tràng phổ biến hơn ở người trẻ, trong khi loét dạ dày thường gặp ở người lớn tuổi.",
                Symptoms = new List<string>
                {
                    "Đau rát, tức ngực vùng thượng vị (dưới xương ức): Đau tăng khi đói (loét tá tràng) hoặc đau sau khi ăn xong (loét dạ dày).",
                    "Ợ chua, ợ hơi, đầy hơi, khó tiêu, có cảm giác chướng bụng.",
                    "Buồn nôn và nôn mửa, thường nôn sau ăn.",
                    "Chán ăn, ăn không ngon miệng dẫn tới sụt cân nhẹ.",
                    "⚡ Dấu hiệu chảy máu tiêu hóa (cấp cứu): Nôn ra máu đỏ/đen hoặc đi ngoài phân đen như hắc ín, có mùi hôi thối dữ dội."
                },
                Causes = new List<string>
                {
                    "Nhiễm vi khuẩn Helicobacter pylori (H. pylori): Chiếm 70-80% nguyên nhân gây loét, lây qua đường ăn uống chung.",
                    "Sử dụng thuốc giảm đau kháng viêm NSAIDs (Ibuprofen, Meloxicam, Aspirin) dài ngày gây bào mòn lớp chất nhầy bảo vệ.",
                    "Stress, căng thẳng thần kinh kéo dài kích thích tăng tiết acid dạ dày.",
                    "Chế độ ăn uống không điều độ: Bỏ bữa, ăn quá cay nóng, nhiều dầu mỡ, uống nhiều bia rượu, cà phê.",
                    "Hút thuốc lá: Nicotine làm cản trở quá trình tưới máu niêm mạc dạ dày."
                },
                Impacts = new List<string>
                {
                    "Xuất huyết tiêu hóa nặng gây mất máu, sốc giảm thể tích.",
                    "Thủng dạ dày - tá tràng dẫn tới viêm phúc mạc nguy hiểm tính mạng cần mổ cấp cứu.",
                    "Hẹp môn vị làm cản trở thức ăn xuống ruột, gây nôn trớ liên tục.",
                    "Tăng nguy cơ tiến triển thành ung thư dạ dày (đặc biệt là loét dạ dày mạn tính do vi khuẩn HP)."
                },
                Treatments = new List<string>
                {
                    "Thuốc ức chế bơm proton (PPI): Omeprazole, Esomeprazole, Pantoprazole giúp giảm tiết acid tối đa để ổ loét tự lành.",
                    "Phác đồ tiệt trừ H. pylori (nếu xét nghiệm dương tính): Phối hợp PPI với 2 hoặc 3 loại kháng sinh (Amoxicillin, Clarithromycin, Metronidazole/Tinidazole, Bismuth) trong 14 ngày liên tục.",
                    "Thuốc trung hòa acid dạ dày (Antacid) và bảo vệ niêm mạc (Sucralfate, Phosphalugel) uống trước ăn.",
                    "Nội soi dạ dày can thiệp để kẹp clip cầm máu trong trường hợp ổ loét đang chảy máu."
                },
                Prevention = "Ăn chín uống sôi, không dùng chung bát nước chấm để tránh lây nhiễm vi khuẩn HP. Ăn uống đúng giờ, nhai kỹ, không bỏ bữa. Hạn chế sử dụng thuốc giảm đau NSAIDs khi chưa có chỉ định. Hạn chế rượu bia, đồ uống có gas, đồ ăn chua cay. Duy trì tinh thần thoải mái, tránh lo âu căng thẳng.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 1251/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị bệnh lý Tiêu hóa của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Khuyến cáo chỉ định nội soi dạ dày tá tràng kết hợp sinh thiết làm test nhanh Urease để chẩn đoán xác định ổ loét và tình trạng nhiễm HP.",
                        "Bắt buộc kiểm tra lại tình trạng tiệt trừ vi khuẩn HP bằng test thở urea (Urea Breath Test) ít nhất 4 tuần sau khi hoàn thành phác đồ kháng sinh.",
                        "Chỉ định điều trị PPI duy trì từ 4 đến 8 tuần tùy thuộc vào vị trí và kích thước của ổ loét."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Helicobacter pylori Eradication to Prevent Gastric Cancer",
                        Journal = "The New England Journal of Medicine",
                        Summary = "Nghiên cứu theo dõi dài hạn chứng minh việc điều trị tiệt trừ vi khuẩn HP thành công giúp giảm 53% nguy cơ phát triển ung thư dạ dày ở những người có tổn thương tiền ung thư trước đó."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Ung thư dạ dày", Description = "Bệnh lý ác tính có triệu chứng ban đầu rất dễ nhầm lẫn với viêm loét dạ dày thông thường." }
                },
                Icon = "gastroenterology",
                ImageUrl = "/images/gastric_ulcer.png"
            },
            new()
            {
                Id = "trao-nguoc-gerd",
                CategoryId = "digestive",
                CategoryName = "Nội Tiêu hóa",
                Name = "Trào ngược dạ dày thực quản (GERD)",
                ShortDescription = "Acid dạ dày trào ngược lên thực quản gây kích ứng niêm mạc, dẫn tới cảm giác ợ nóng, trớ thức ăn và ho khan kéo dài.",
                Overview = "Trào ngược dạ dày thực quản (GERD) là tình trạng dịch dạ dày (bao gồm acid, enzyme pepsin và dịch mật) trào ngược lên thực quản theo chu kỳ hoặc thường xuyên, gây tổn thương niêm mạc thực quản và các cơ quan hô hấp trên. Bệnh xảy ra do sự suy yếu của cơ thắt thực quản dưới (LES) — chiếc van ngăn cách thực quản và dạ dày.",
                Symptoms = new List<string>
                {
                    "Ợ nóng: Cảm giác nóng rát từ vùng thượng vị lan lên dọc sau xương ức đến cổ họng.",
                    "Ợ chua, trớ thức ăn hoặc dịch vị chua lên miệng, đặc biệt khi cúi người hoặc sau khi ăn no.",
                    "Đau ngực không do tim: Cảm giác thắt nghẹn vùng ngực do acid kích thích dây thần kinh thực quản.",
                    "Ho khan kéo dài, khàn tiếng vào buổi sáng, đau họng mạn tính do acid trào ngược kích thích thanh quản.",
                    "Nuốt nghẹn, nuốt vướng hoặc cảm giác có cục nghẹn ở cổ họng (cảm giác toàn cầu)."
                },
                Causes = new List<string>
                {
                    "Suy giảm chức năng cơ thắt thực quản dưới (LES) do bẩm sinh, lão hóa hoặc tác dụng phụ của thuốc.",
                    "Tăng áp lực trong dạ dày: Béo phì, mang thai hoặc mặc quần áo quá chật.",
                    "Thoát vị hoành: Một phần dạ dày bị đẩy lên trên cơ hoành, làm suy yếu chiếc van LES.",
                    "Ăn quá no, nằm ngay sau khi ăn xong, ăn nhiều đồ ăn dầu mỡ khó tiêu gây ứ đọng thức ăn.",
                    "Stress, lo âu làm tăng nhạy cảm thực quản và kích thích co bóp dạ dày."
                },
                Impacts = new List<string>
                {
                    "Viêm thực quản trợt loét, gây đau đớn khi nuốt.",
                    "Hẹp thực quản do hình thành mô sẹo từ các vết loét do acid.",
                    "Thực quản Barrett: Tế bào niêm mạc thực quản biến đổi cấu trúc do tiếp xúc acid lâu ngày, là tổn thương tiền ung thư.",
                    "Viêm họng, viêm thanh quản mạn tính và làm trầm trọng thêm bệnh hen phế quản."
                },
                Treatments = new List<string>
                {
                    "Điều trị nội khoa: Sử dụng thuốc giảm tiết acid PPI (Esomeprazole, Rabeprazole) liều chuẩn từ 4 đến 8 tuần.",
                    "Thuốc prokinetic (Domperidone, Itopride) giúp tăng tốc độ làm rỗng dạ dày và tăng trương lực cơ thắt LES.",
                    "Thuốc bảo vệ niêm mạc tạo màng chắn cơ học ngăn acid (Gaviscon, Phosphalugel) uống ngay sau ăn.",
                    "Thay đổi lối sống triệt để: Chia nhỏ bữa ăn, không ăn trong vòng 3 giờ trước khi đi ngủ, kê cao đầu giường 15cm khi ngủ."
                },
                Prevention = "Duy trì cân nặng hợp lý, tránh béo phì. Kiêng hoàn toàn các chất kích thích cơ thắt thực quản dưới như: thuốc lá, rượu bia, cà phê, sô-cô-la, đồ ăn chiên rán nhiều mỡ. Không nằm hoặc vận động mạnh ngay sau khi ăn.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 1251/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị bệnh lý trào ngược thực quản của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Chẩn đoán chủ yếu dựa trên bảng câu hỏi GERD-Q và thử nghiệm lâm sàng bằng PPI (PPI Test) trong 2 tuần.",
                        "Nội soi thực quản dạ dày chỉ định khi bệnh nhân có dấu hiệu cảnh báo (nuốt nghẹn, sụt cân) hoặc không đáp ứng với điều trị PPI ban đầu.",
                        "Khuyến cáo phẫu thuật nội soi tái tạo nếp gấp đáy vị (phẫu thuật Nissen) chỉ dành cho các trường hợp GERD nặng kháng thuốc PPI hoặc có thoát vị hoành lớn."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Proton Pump Inhibitors in GERD: A Systematic Review",
                        Journal = "American Journal of Gastroenterology",
                        Summary = "Đánh giá hệ thống cho thấy thuốc PPI đạt tỷ lệ làm lành tổn thương viêm thực quản do trào ngược lên tới 85-90% sau 8 tuần điều trị, vượt trội hoàn toàn so với nhóm kháng H2."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Thực quản Barrett", Description = "Biến chứng biến đổi tế bào niêm mạc thực quản, cần nội soi theo dõi định kỳ để tầm soát sớm ung thư thực quản." }
                },
                Icon = "gastroenterology",
                ImageUrl = "/images/gerd.jpg"
            },
            new()
            {
                Id = "viem-gan-b",
                CategoryId = "digestive",
                CategoryName = "Nội Tiêu hóa",
                Name = "Viêm gan siêu vi B (Hepatitis B)",
                ShortDescription = "Bệnh lý nhiễm trùng gan do virus HBV. Việt Nam là vùng dịch tễ cao, tiềm ẩn nguy cơ xơ gan và ung thư gan.",
                Overview = "Viêm gan B là một bệnh nhiễm trùng gan đe dọa tính mạng do virus viêm gan B (HBV) gây ra. Virus này tấn công tế bào gan, gây viêm gan cấp tính hoặc mạn tính. Khoảng 90% người lớn bị nhiễm HBV cấp tính sẽ tự phục hồi hoàn toàn và có kháng thể trọn đời, nhưng ở trẻ sơ sinh lây truyền từ mẹ, tỷ lệ chuyển sang viêm gan B mạn tính lên tới 90%, dẫn đến nguy cơ cao bị xơ gan và ung thư biểu mô tế bào gan (HCC) sau này.",
                Symptoms = new List<string>
                {
                    "Nhiều trường hợp viêm gan B mạn tính hoàn toàn không có triệu chứng lâm sàng rõ rệt trong nhiều năm.",
                    "Mệt mỏi kéo dài, chán ăn, sợ các món ăn có nhiều dầu mỡ.",
                    "Đau tức hoặc căng nặng vùng hạ sườn phải (vùng gan).",
                    "Vàng mắt, vàng da, nước tiểu sẫm màu như nước trà đặc (thường gặp trong đợt cấp tính hoặc suy gan).",
                    "Rối loạn tiêu hóa: Đầy bụng, khó tiêu, đi ngoài phân lỏng."
                },
                Causes = new List<string>
                {
                    "Lây truyền qua đường máu: Dùng chung bơm kim tiêm, dụng cụ xăm trổ, dao cạo râu, bàn chải đánh răng hoặc tai nạn kim tiêm.",
                    "Lây truyền từ mẹ sang con: Thường xảy ra trong quá trình sinh đẻ khi máu mẹ tiếp xúc trực tiếp với máu con.",
                    "Lây truyền qua đường tình dục: Quan hệ tình dục không an toàn với người nhiễm HBV mà không có biện pháp bảo vệ.",
                    "❌ Lưu ý: Viêm gan B không lây qua tiếp xúc thông thường như bắt tay, ôm, dùng chung chén bát hoặc qua đường hô hấp."
                },
                Impacts = new List<string>
                {
                    "Xơ gan: Các tế bào gan bị phá hủy thay thế bằng các dải xơ hóa, làm suy giảm chức năng gan trầm trọng.",
                    "Ung thư gan (HCC): HBV tích hợp DNA vào tế bào gan gây đột biến gen phát triển khối u ác tính.",
                    "Suy gan cấp tính: Tình trạng gan bị hủy hoại ồ ạt dẫn đến hôn mê gan, rối loạn đông máu nặng.",
                    "Các biến chứng ngoài gan: Viêm cầu thận, viêm đa động mạch nút."
                },
                Treatments = new List<string>
                {
                    "Không cần dùng thuốc kháng virus đối với người mang virus không hoạt động (dung nạp miễn dịch) — chỉ cần theo dõi định kỳ mỗi 3-6 tháng.",
                    "Thuốc kháng virus đường uống (uống hàng ngày, kéo dài suốt đời): Tenofovir (TDF hoặc TAF) hoặc Entecavir giúp ức chế tối đa sự nhân lên của virus.",
                    "Tiêm kháng huyết thanh (HBIG) phối hợp vắc xin viêm gan B cho trẻ sơ sinh có mẹ nhiễm HBV trong vòng 24 giờ đầu sau sinh.",
                    "Tuyệt đối không tự ý ngưng thuốc kháng virus vì có thể kích hoạt đợt bùng phát viêm gan cấp tính gây suy gan."
                },
                Prevention = "Tiêm vắc xin viêm gan B đầy đủ là biện pháp phòng ngừa hiệu quả nhất (>95%). Không dùng chung các vật dụng cá nhân có nguy cơ dính máu. Quan hệ tình dục an toàn (sử dụng bao cao su). Khám sức khỏe tầm soát viêm gan B trước khi kết hôn hoặc mang thai.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 3310/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị bệnh viêm gan vi rút B của Bộ Y tế Việt Nam",
                    Recommendations = new List<string>
                    {
                        "Chỉ định điều trị thuốc kháng virus khi HBsAg (+) kéo dài trên 6 tháng kèm tải lượng virus HBV-DNA cao và nồng độ men gan ALT tăng gấp đôi bình thường, hoặc có bằng chứng xơ hóa gan rõ.",
                        "Tầm soát ung thư gan định kỳ mỗi 3-6 tháng bằng siêu âm ổ bụng và định lượng chỉ số AFP máu đối với tất cả bệnh nhân viêm gan B mạn tính.",
                        "Khuyến cáo sử dụng Tenofovir điều trị dự phòng lây truyền từ mẹ sang con từ tuần thứ 24-28 của thai kỳ cho sản phụ có tải lượng virus cao."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Tenofovir Alafenamide (TAF) vs Tenofovir Disoproxil Fumarate (TDF) in Chronic HBV",
                        Journal = "The Journal of Hepatology",
                        Summary = "Thử nghiệm so sánh cho thấy thuốc TAF duy trì hiệu quả ức chế virus tương đương TDF nhưng giảm thiểu đáng kể tác dụng phụ gây suy thận và loãng xương ở bệnh nhân phải điều trị lâu dài."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Xơ gan mất bù", Description = "Giai đoạn cuối của xơ gan gây cổ trướng (trướng bụng dịch), vàng da nặng, xuất huyết tiêu hóa do vỡ giãn tĩnh mạch thực quản." }
                },
                Icon = "science",
                ImageUrl = "/images/hepatitis_b.png"
            },

            // ==================== NỘI TIM MẠCH ====================
            new()
            {
                Id = "tang-huyet-ap",
                CategoryId = "cardio",
                CategoryName = "Nội Tim mạch",
                Name = "Tăng huyết áp (Hypertension)",
                ShortDescription = "Được mệnh danh là 'Kẻ giết người thầm lặng'. Bệnh lý tim mạch phổ biến nhất, gây biến chứng đột quỵ và nhồi máu cơ tim.",
                Overview = "Tăng huyết áp là tình trạng áp lực máu tác động lên thành động mạch tăng cao liên tục. Theo chuẩn của Bộ Y tế Việt Nam và Hội Tim mạch học Quốc gia, tăng huyết áp được xác định khi huyết áp tâm thu ≥ 140 mmHg và/hoặc huyết áp tâm trương ≥ 90 mmHg khi đo tại phòng khám. Phần lớn các trường hợp (90-95%) là tăng huyết áp vô căn (không có nguyên nhân trực tiếp).",
                Symptoms = new List<string>
                {
                    "Phần lớn người bệnh tăng huyết áp không xuất hiện bất kỳ triệu chứng lâm sàng nào (chỉ phát hiện tình cờ khi đo huyết áp).",
                    "Đau nhức đầu vùng chẩm, sau gáy, thường đau vào sáng sớm.",
                    "Chóng mặt, ù tai, hoa mắt, nhìn mờ đột ngột.",
                    "Hồi hộp, đánh trống ngực, đôi khi có cảm giác tức nặng ngực.",
                    "⚡ Dấu hiệu cơn tăng huyết áp ác tính: Huyết áp đột ngột tăng vọt >180/120 mmHg kèm theo khó thở dữ dội, tức ngực, nhìn mờ, co giật hoặc liệt nửa người."
                },
                Causes = new List<string>
                {
                    "Tăng huyết áp nguyên phát (vô căn): Liên quan đến các yếu tố nguy cơ như tuổi cao, di truyền, chế độ ăn mặn.",
                    "Chế độ ăn nhiều muối: Ăn mặn làm giữ nước trong máu, tăng thể tích tuần hoàn và co thắt động mạch.",
                    "Lối sống ít vận động, béo phì (đặc biệt là béo bụng)."
                },
                Impacts = new List<string>
                {
                    "Não: Gây đột quỵ nhồi máu não hoặc xuất huyết não.",
                    "Tim: Phì đại thất trái, dẫn tới suy tim, nhồi máu cơ tim cấp.",
                    "Thận: Suy thận mạn tính do tổn thương các cầu thận.",
                    "Mắt: Tổn thương võng mạc gây giảm thị lực, mù lòa."
                },
                Treatments = new List<string>
                {
                    "Sử dụng thuốc hạ áp đều đặn mỗi ngày lâu dài suốt đời (ngay cả khi huyết áp đã trở lại bình thường).",
                    "Các nhóm thuốc đầu tay: Ức chế men chuyển (Captopril, Enalapril), Ức chế thụ thể Angiotensin II (Losartan, Valsartan), Chẹn kênh Canxi (Amlodipine), Thuốc lợi tiểu (Hydrochlorothiazide).",
                    "Thực hiện chế độ ăn nhạt (< 5g muối/ngày, khoảng 1 thìa cà phê muối).",
                    "Tránh dùng các chất kích thích và thuốc làm tăng huyết áp (corticoid, cam thảo)."
                },
                Prevention = "Duy trì cân nặng ở mức hợp lý (BMI 18.5 - 22.9). Hạn chế muối trong nêm nếm thức ăn. Tăng cường rau xanh, trái cây, các loại hạt (chế độ ăn DASH). Tập thể dục nhịp điệu (đi bộ nhanh, chạy bộ, bơi lội) ít nhất 30-45 phút mỗi ngày. Bỏ hoàn toàn thuốc lá.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 3192/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị Tăng huyết áp của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Khuyến cáo đo huyết áp đúng kỹ thuật (nghỉ ngơi 5 phút trước đo, đo ở tư thế ngồi, đo ít nhất 2 lần cách nhau 2 phút) để chẩn đoán chính xác.",
                        "Đặt mục tiêu huyết áp kiểm soát chung là < 130/80 mmHg cho hầu hết bệnh nhân nếu dung nạp tốt, đặc biệt là bệnh nhân kèm đái tháo đường hoặc suy thận.",
                        "Khuyên phối hợp hai loại thuốc hạ áp liều thấp ngay từ đầu (trong một viên phối hợp cố định) đối với bệnh nhân tăng huyết áp độ 2 hoặc có nguy cơ tim mạch cao."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Systolic Blood Pressure Intervention Trial (SPRINT)",
                        Journal = "New England Journal of Medicine",
                        Summary = "Thử nghiệm lâm sàng quy mô lớn chứng minh việc kiểm soát huyết áp tâm thu tích cực xuống mục tiêu dưới 120 mmHg giúp giảm 25% các biến cố tim mạch lớn và giảm 27% tỷ lệ tử vong so với mục tiêu thông thường dưới 140 mmHg."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Suy tim mạn tính", Description = "Hậu quả của việc cơ tim phải co bóp chống lại áp lực động mạch cao kéo dài, khiến tim bị giãn rộng và suy yếu chức năng bơm máu." }
                },
                Icon = "favorite",
                ImageUrl = "/images/hypertension.jpg"
            },
            new()
            {
                Id = "thieu-mau-co-tim",
                CategoryId = "cardio",
                CategoryName = "Nội Tim mạch",
                Name = "Thiếu máu cơ tim (Bệnh động mạch vành)",
                ShortDescription = "Tình trạng hẹp lòng động mạch vành cấp máu cho tim do các mảng xơ vữa, gây ra những cơn đau thắt ngực khi gắng sức.",
                Overview = "Thiếu máu cơ tim xảy ra khi lưu lượng máu đến cơ tim bị giảm, khiến cơ tim không nhận đủ oxy cần thiết để co bóp. Nguyên nhân phổ biến nhất là bệnh động mạch vành — tình trạng tích tụ các mảng xơ vữa (chứa cholesterol và canxi) bám vào thành động mạch vành làm hẹp lòng mạch. Bệnh có thể diễn tiến thành Nhồi máu cơ tim cấp cực kỳ nguy hiểm do nứt vỡ mảng xơ vữa tạo huyết khối gây tắc nghẽn hoàn toàn động mạch vành.",
                Symptoms = new List<string>
                {
                    "Đau thắt ngực ổn định: Cảm giác đè nén, bóp nghẹt ở vùng sau xương ức hoặc ngực trái, xuất hiện khi gắng sức (đi bộ nhanh, leo cầu thang) hoặc xúc động mạnh, giảm đau khi nghỉ ngơi hoặc ngậm thuốc giãn vành.",
                    "Đau lan ra vai trái, dọc theo cánh tay trái xuống ngón tay, hoặc lan lên cổ, hàm, sau lưng.",
                    "⚡ Đau thắt ngực không ổn định (Hội chứng vành cấp): Cơn đau ngực xuất hiện cả khi nghỉ ngơi, kéo dài trên 20 phút, không đỡ khi ngậm thuốc — là dấu hiệu báo động của nhồi máu cơ tim cấp cần cấp cứu ngay lập tức.",
                    "Khó thở, mệt mỏi khi gắng sức, vã mồ hôi lạnh, hồi hộp đi kèm cơn đau ngực."
                },
                Causes = new List<string>
                {
                    "Xơ vữa động mạch vành: Tích tụ các chất béo xấu trên thành động mạch vành.",
                    "Hút thuốc lá: Làm tổn thương nội mạc mạch máu và gây co thắt động mạch vành cấp tính.",
                    "Rối loạn lipid máu: Tăng LDL-Cholesterol (cholesterol xấu) và giảm HDL-Cholesterol (cholesterol tốt).",
                    "Đái tháo đường, tăng huyết áp: Đẩy nhanh quá trình xơ vữa mạch máu.",
                    "Tuổi tác và yếu tố gia đình: Nam giới trên 45 tuổi, nữ giới trên 55 tuổi có nguy cơ cao hơn."
                },
                Impacts = new List<string>
                {
                    "Nhồi máu cơ tim cấp gây tử vong đột ngột do loạn nhịp tim hoặc sốc tim.",
                    "Suy tim mạn tính do cơ tim bị thiếu máu nuôi dưỡng lâu ngày bị xơ hóa.",
                    "Rối loạn nhịp tim nặng (rung thất, nhịp nhanh thất) đe dọa mạng sống."
                },
                Treatments = new List<string>
                {
                    "Điều trị nội khoa: Sử dụng thuốc kháng kết tập tiểu cầu (Aspirin, Clopidogrel) giúp ngăn ngừa huyết khối.",
                    "Thuốc chẹn beta giao cảm (Metoprolol, Bisoprolol) giúp giảm nhịp tim và nhu cầu oxy của cơ tim.",
                    "Thuốc giãn động mạch vành (Nitroglycerin ngậm dưới lưỡi khi đau ngực cấp).",
                    "Thuốc hạ mỡ máu nhóm statin (Atorvastatin, Rosuvastatin) liều cao để ổn định mảng xơ vữa.",
                    "Can thiệp động mạch vành qua da (PCI): Đặt Stent để nong rộng lòng động mạch bị hẹp khẩn cấp trong nhồi máu cơ tim.",
                    "Phẫu thuật bắc cầu chủ - vành (CABG) đối với trường hợp hẹp nhiều thân động mạch vành phức tạp."
                },
                Prevention = "Duy trì chế độ ăn ít chất béo bão hòa, không ăn mỡ động vật và nội tạng. Bỏ hút thuốc lá tuyệt đối. Kiểm soát tốt huyết áp và đường huyết. Tập thể dục đều đặn phù hợp với tình trạng sức khỏe tim mạch theo hướng dẫn của bác sĩ.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 1845/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị hội chứng mạch vành cấp của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Bắt buộc đo điện tâm đồ 12 chuyển đạo (ECG) trong vòng 10 phút kể từ khi bệnh nhân đến phòng cấp cứu vì đau ngực.",
                        "Xét nghiệm định lượng Troponin tim siêu nhạy (hs-cTn) tại các thời điểm 0h và 1-3h để chẩn đoán loại trừ hoặc xác định nhồi máu cơ tim không ST chênh lên.",
                        "Khuyến cáo thực hiện can thiệp mạch vành thì đầu (PCI) trong vòng 120 phút từ khi chẩn đoán xác định nhồi máu cơ tim cấp có ST chênh lên (STEMI)."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "ISCHEMIA Trial: Clinical Outcomes of Initial Invasive vs Conservative Strategy",
                        Journal = "The New England Journal of Medicine",
                        Summary = "Thử nghiệm lâm sàng lớn cho thấy đối với bệnh nhân thiếu máu cơ tim ổn định từ trung bình đến nặng, chiến lược can thiệp sớm không giúp giảm tỷ lệ tử vong hoặc nhồi máu cơ tim so với điều trị nội khoa tối ưu đơn thuần, ngoại trừ việc giúp cải thiện triệu chứng đau ngực tốt hơn."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Nhồi máu cơ tim cấp", Description = "Tình trạng hoại tử một phần cơ tim do tắc nghẽn hoàn toàn động mạch vành đột ngột, gây đau ngực dữ dội, nguy kịch." }
                },
                Icon = "monitoring",
                ImageUrl = "/images/ischemic_heart.png"
            },
            new()
            {
                Id = "roi-loan-nhip-tim",
                CategoryId = "cardio",
                CategoryName = "Nội Tim mạch",
                Name = "Rối loạn nhịp tim (Rung nhĩ)",
                ShortDescription = "Tình trạng hoạt động điện học bất thường của tim làm tim đập quá nhanh, quá chậm hoặc hoàn toàn không đều. Rung nhĩ tăng nguy cơ đột quỵ gấp 5 lần.",
                Overview = "Rối loạn nhịp tim là một nhóm các tình trạng bất thường về tần số hoặc nhịp điệu đập của tim. Trong đó, Rung nhĩ (Atrial Fibrillation - AF) là dạng rối loạn nhịp tim nhanh phổ biến nhất ở người lớn tuổi. Trong rung nhĩ, hai tâm nhĩ của tim rung lên hỗn loạn thay vì co bóp nhịp nhàng, dẫn tới ứ đọng máu ở tâm nhĩ dễ hình thành cục máu đông di chuyển lên não gây đột quỵ tắc mạch.",
                Symptoms = new List<string>
                {
                    "Hồi hộp, đánh trống ngực: Cảm giác tim đập thình thịch, đập hẫng nhịp hoặc đập loạn nhịp trong lồng ngực.",
                    "Mệt mỏi, suy giảm khả năng gắng sức do cung lượng tim giảm.",
                    "Chóng mặt, xây xẩm mặt mày, đôi khi bị ngất xỉu đột ngột.",
                    "Khó thở, tức ngực nhẹ khi tim đập quá nhanh.",
                    "Mạch đập không đều: Nhịp tim và nhịp mạch hoàn toàn không trùng khớp về cường độ và tần số."
                },
                Causes = new List<string>
                {
                    "Tăng huyết áp lâu ngày không kiểm soát tốt gây phì đại và xơ hóa tâm nhĩ.",
                    "Bệnh van tim: Hẹp hở van hai lá làm giãn buồng tim trái.",
                    "Bệnh tim thiếu máu cục bộ làm cơ tim bị tổn thương xơ hóa.",
                    "Cường giáp: Nồng độ hormone tuyến giáp cao kích thích trực tiếp cơ tim gây nhịp nhanh, rung nhĩ.",
                    "Lạm dụng rượu bia quá mức, sử dụng nhiều chất kích thích (cafein, amphetamine)."
                },
                Impacts = new List<string>
                {
                    "Đột quỵ não: Cục máu đông từ tâm nhĩ trái bong ra trôi theo dòng máu gây tắc động mạch não.",
                    "Suy tim: Tim đập quá nhanh kéo dài làm suy kiệt cơ tim.",
                    "Sa sút trí tuệ do giảm tưới máu não mạn tính."
                },
                Treatments = new List<string>
                {
                    "Kiểm soát tần số tim: Sử dụng thuốc chẹn beta (Metoprolol), chẹn kênh canxi non-dihydropyridine (Verapamil) hoặc Digoxin để duy trì nhịp tim lúc nghỉ <100 chu kỳ/phút.",
                    "Kiểm soát nhịp (chuyển về nhịp xoang): Dùng thuốc chống loạn nhịp (Amiodarone) hoặc sốc điện chuyển nhịp.",
                    "Sử dụng thuốc chống đông máu trực tiếp đường uống (DOAC - như Dabigatran, Rivaroxaban) để ngăn ngừa cục máu đông gây đột quỵ.",
                    "Triệt đốt rung nhĩ bằng năng lượng sóng có tần số vô tuyến qua ống thông (Catheter Ablation) để điều trị triệt để."
                },
                Prevention = "Hạn chế tối đa rượu bia, cafein. Kiểm soát tốt huyết áp, đường huyết và chức năng tuyến giáp. Tránh căng thẳng, thức khuya. Thực hiện chế độ ăn lành mạnh và tập thể dục thể thao vừa sức phù hợp với lời khuyên bác sĩ.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 2100/QĐ-BYT",
                    Title = "Hướng dẫn điều trị và kiểm soát Rung nhĩ của Bộ Y tế",
                    Recommendations = new List<string>
                    {
                        "Khuyến cáo sử dụng thang điểm CHA2DS2-VASc để đánh giá nguy cơ đột quỵ và chỉ định thuốc chống đông cho tất cả bệnh nhân rung nhĩ (bắt buộc khi điểm ≥ 2 ở nam hoặc ≥ 3 ở nữ).",
                        "Khuyên dùng thuốc chống đông đường uống thế hệ mới (DOAC) thay thế cho kháng vitamin K (Warfarin) vì tính an toàn cao hơn và không cần xét nghiệm máu INR định kỳ.",
                        "Sử dụng thang điểm HAS-BLED để đánh giá nguy cơ chảy máu trước khi khởi động liệu pháp chống đông."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Apixaban versus Warfarin in Patients with Atrial Fibrillation (ARISTOTLE)",
                        Journal = "New England Journal of Medicine",
                        Summary = "Thử nghiệm lâm sàng chứng minh thuốc chống đông thế hệ mới Apixaban vượt trội hơn Warfarin trong việc ngăn ngừa đột quỵ tắc mạch, đồng thời giảm 31% nguy cơ biến chứng chảy máu nghiêm trọng (đặc biệt là chảy máu não)."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Cường giáp trạng (Basedow)", Description = "Tuyến giáp hoạt động quá mức giải phóng nhiều hormone giáp, là nguyên nhân nội tiết phổ biến gây rung nhĩ kịch phát." }
                },
                Icon = "heart_cough",
                ImageUrl = "/images/arrhythmia.png"
            },

            // ==================== NỘI TIẾT & CHUYỂN HÓA ====================
            new()
            {
                Id = "dai-thao-duong",
                CategoryId = "endocrine",
                CategoryName = "Nội tiết & Chuyển hóa",
                Name = "Đái tháo đường Type 2 (Tiểu đường)",
                ShortDescription = "Bệnh lý rối loạn chuyển hóa glucose mạn tính do kháng insulin. Gây biến chứng nặng nề lên tim, thận, mắt và bàn chân.",
                Overview = "Đái tháo đường Type 2 là bệnh lý rối loạn chuyển hóa đặc trưng bởi tình trạng tăng glucose (đường) máu mạn tính, kết hợp với rối loạn chuyển hóa lipid và protein. Bệnh xảy ra do hai cơ chế phối hợp: tế bào cơ thể kháng lại tác dụng của hormone insulin (kháng insulin) và tuyến tụy suy giảm khả năng bài tiết đủ insulin để điều hòa đường huyết.",
                Symptoms = new List<string>
                {
                    "Ăn nhiều: Cảm giác nhanh đói, thèm ăn đồ ngọt liên tục do tế bào bị thiếu năng lượng.",
                    "Uống nhiều: Luôn cảm thấy khô miệng, khát nước dữ dội, uống nước liên tục.",
                    "Tiểu nhiều: Đi tiểu nhiều lần trong ngày, đặc biệt là tiểu đêm do cơ thể đào thải đường dư qua nước tiểu.",
                    "Gầy sút cân nhiều: Sụt cân nhanh chóng không rõ lý do dù ăn uống nhiều.",
                    "Mệt mỏi kéo dài, nhìn mờ, tê bì đầu ngón tay ngón chân, vết thương trầy xước lâu lành."
                },
                Causes = new List<string>
                {
                    "Kháng Insulin: Thường liên quan mật thiết đến thừa cân, béo phì (đặc biệt là béo bụng).",
                    "Lối sống tĩnh tại: Lười vận động làm giảm khả năng tiêu thụ glucose của cơ bắp.",
                    "Chế độ ăn nhiều carbohydrate tinh chế (đường, bánh mì trắng, nước ngọt) gây áp lực lớn lên tuyến tụy.",
                    "Yếu tố di truyền: Có bố, mẹ hoặc anh chị em ruột bị tiểu đường.",
                    "Tuổi tác: Nguy cơ tăng cao ở người trên 45 tuổi (tuy nhiên bệnh đang có xu hướng trẻ hóa mạnh mẽ)."
                },
                Impacts = new List<string>
                {
                    "Biến chứng mạch máu lớn: Nhồi máu cơ tim, đột quỵ não, bệnh động mạch chi dưới gây hoại tử bàn chân.",
                    "Biến chứng mạch máu nhỏ: Suy thận mạn giai đoạn cuối, bệnh võng mạc đái tháo đường gây mù lòa.",
                    "Biến chứng thần kinh: Tê bì, mất cảm giác đau ở bàn chân dẫn tới các vết loét nhiễm trùng không hay biết phải đoạn chi.",
                    "Hạ đường huyết nguy kịch do lạm dụng thuốc quá liều."
                },
                Treatments = new List<string>
                {
                    "Thuốc uống hạ đường huyết: **Metformin** là thuốc lựa chọn đầu tay giúp tăng nhạy cảm insulin ở tế bào.",
                    "Các nhóm thuốc thế hệ mới: Thuốc ức chế SGLT2 (Dapagliflozin) giúp thải đường qua nước tiểu (ưu việt cho người suy tim, suy thận); Thuốc đồng vận thụ thể GLP-1.",
                    "Liệu pháp tiêm Insulin: Chỉ định bắt buộc khi tuyến tụy suy kiệt không còn khả năng tiết insulin hoặc khi có biến chứng cấp tính.",
                    "Theo dõi định kỳ chỉ số đường huyết đói và chỉ số HbA1c (mục tiêu HbA1c < 7.0% cho hầu hết người lớn).",
                    "Kiểm soát chế độ ăn khắt khe: Hạn chế tinh bột nhanh, kiêng đường ngọt, chia nhỏ bữa ăn."
                },
                Prevention = "Duy trì cân nặng khỏe mạnh (giảm cân nếu thừa cân). Thực hiện chế độ ăn giàu chất xơ, ăn nhiều ngũ cốc nguyên hạt thay cho gạo trắng. Vận động thể lực ít nhất 150 phút/tuần (30 phút/ngày, 5 ngày/tuần). Khám sức khỏe xét nghiệm đường huyết đói hàng năm để phát hiện sớm giai đoạn tiền đái tháo đường.",
                MohGuidelines = new MinistryGuidelines
                {
                    DocumentNumber = "QĐ 5481/QĐ-BYT",
                    Title = "Hướng dẫn chẩn đoán và điều trị đái tháo đường Týp 2 của Bộ Y tế Việt Nam",
                    Recommendations = new List<string>
                    {
                        "Chẩn đoán đái tháo đường dựa trên một trong các tiêu chuẩn: Đường huyết đói ≥ 126 mg/dL (7.0 mmol/L), hoặc đường huyết 2h sau nghiệm pháp dung nạp glucose ≥ 200 mg/dL (11.1 mmol/L), hoặc HbA1c ≥ 6.5%.",
                        "Khuyến cáo cá thể hóa mục tiêu điều trị dựa trên tuổi, thời gian mắc bệnh và các biến chứng đi kèm của bệnh nhân.",
                        "Ưu tiên phối hợp sớm thuốc ức chế SGLT2 hoặc đồng vận GLP-1 cho bệnh nhân đái tháo đường đã có bệnh tim mạch do xơ vữa, suy tim hoặc bệnh thận mạn tính, độc lập với nồng độ HbA1c nền."
                    }
                },
                Evidences = new List<ClinicalEvidence>
                {
                    new()
                    {
                        Title = "Empagliflozin, Cardiovascular Outcomes, and Mortality in Type 2 Diabetes",
                        Journal = "The New England Journal of Medicine (EMPA-REG OUTCOME)",
                        Summary = "Thử nghiệm lâm sàng chứng minh thuốc ức chế SGLT2 giúp giảm 38% nguy cơ tử vong do tim mạch và giảm 35% tỷ lệ nhập viện vì suy tim ở bệnh nhân đái tháo đường Type 2 có nguy cơ tim mạch cao."
                    }
                },
                RelatedDiseases = new List<RelatedDisease>
                {
                    new() { Name = "Hội chứng chuyển hóa", Description = "Tập hợp các yếu tố gồm béo bụng, tăng huyết áp, tăng đường huyết đói và rối loạn mỡ máu, tiền đề của đái tháo đường." }
                },
                Icon = "bloodtype",
                ImageUrl = "/images/diabetes.png"
            },
        };

        public static List<SymptomCategory> GetCategories() => _categories;

        public static List<SymptomDetail> GetAllDiseases() => _diseases;

        public static List<SymptomDetail> GetDiseasesByCategory(string categoryId)
        {
            return _diseases.Where(d => d.CategoryId.Equals(categoryId, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static SymptomDetail? GetDiseaseById(string id)
        {
            return _diseases.FirstOrDefault(d => d.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public static List<SymptomDetail> SearchDiseases(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return new List<SymptomDetail>();
            
            var normalizedQuery = query.ToLower();
            return _diseases.Where(d => 
                d.Name.ToLower().Contains(normalizedQuery) ||
                d.ShortDescription.ToLower().Contains(normalizedQuery) ||
                d.Overview.ToLower().Contains(normalizedQuery) ||
                d.Symptoms.Any(s => s.ToLower().Contains(normalizedQuery)) ||
                d.Causes.Any(c => c.ToLower().Contains(normalizedQuery)) ||
                d.Treatments.Any(t => t.ToLower().Contains(normalizedQuery))
            ).ToList();
        }
    }
}

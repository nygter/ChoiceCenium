using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Choice.Cenium.HotelImportJob;
using HotelImport;

namespace Choice.Cenium.HotelImportJob
{
    class Program
    {
        private const string JsonText =
            @"[ { ""Lon"": 12.64189589, ""Lat"": 55.63707805, ""Name"": ""Quality Airport Hotel Dan"" }, { ""Lon"": 24.1143093109131, ""Lat"": 56.9570999145508, ""Name"": ""Clarion Collection Hotel Valdemars"" }, { ""Lon"": 10.3754301071167, ""Lat"": 63.3591918945313, ""Name"": ""Quality Hotel Panorama"" }, { ""Lon"": 10.9207601547241, ""Lat"": 63.4679794311523, ""Name"": ""Quality Airport Hotel Værnes"" }, { ""Lon"": 10.7796897888184, ""Lat"": 59.8251991271973, ""Name"": ""Quality Hotel Mastemyr"" }, { ""Lon"": 10.4378204345703, ""Lat"": 61.2419891357422, ""Name"": ""Quality Hotel & Resort Hafjell"" }, { ""Lon"": 5.3152871131897, ""Lat"": 60.3962211608887, ""Name"": ""Comfort Hotel Holberg"" }, { ""Lon"": 11.1616296768188, ""Lat"": 60.1635894775391, ""Name"": ""Quality Airport Hotel Gardermoen"" }, { ""Lon"": 5.62910318374634, ""Lat"": 58.892879486084, ""Name"": ""Quality Airport Hotel Stavanger"" }, { ""Lon"": 10.3925399780273, ""Lat"": 63.4308204650879, ""Name"": ""Quality Hotel Augustin"" }, { ""Lon"": 8.1448974609375, ""Lat"": 58.1799011230469, ""Name"": ""Quality Hotel & Resort Kristiansand"" }, { ""Lon"": 5.73755598068237, ""Lat"": 58.8508682250977, ""Name"": ""Quality Hotel Residence"" }, { ""Lon"": 10.7476121, ""Lat"": 59.909305, ""Name"": ""Comfort Hotel Børsparken"" }, { ""Lon"": 5.29249, ""Lat"": 60.292576, ""Name"": ""Quality Hotel Edvard Grieg"" }, { ""Lon"": 6.15191793441772, ""Lat"": 62.472339630127, ""Name"": ""Clarion Collection Hotel Bryggen"" }, { ""Lon"": 10.2237796783447, ""Lat"": 59.133129119873, ""Name"": ""Clarion Collection Hotel Atlantic"" }, { ""Lon"": 10.210470199585, ""Lat"": 59.7368812561035, ""Name"": ""Clarion Collection Hotel Tollboden"" }, { ""Lon"": 5.26669530000004, ""Lat"": 59.4131438, ""Name"": ""Clarion Collection Hotel Amanda"" }, { ""Lon"": 10.4627504348755, ""Lat"": 61.1194000244141, ""Name"": ""Clarion Collection Hotel Hammer"" }, { ""Lon"": 18.9595508575439, ""Lat"": 69.6504135131836, ""Name"": ""Clarion Collection Hotel With"" }, { ""Lon"": 10.4027795791626, ""Lat"": 63.4341506958008, ""Name"": ""Clarion Collection Hotel Bakeriet"" }, { ""Lon"": 10.4040699005127, ""Lat"": 63.4339294433594, ""Name"": ""Clarion Collection Hotel Grand Olav"" }, { ""Lon"": 9.74485969543457, ""Lat"": 59.014030456543, ""Name"": ""Quality Hotel & Resort Skjærgården"" }, { ""Lon"": 10.7502298355103, ""Lat"": 59.9125518798828, ""Name"": ""Clarion Hotel Royal Christiania"" }, { ""Lon"": 5.31920220000006, ""Lat"": 60.3957493, ""Name"": ""Clarion Hotel Admiral"" }, { ""Lon"": 8.76778411865234, ""Lat"": 58.4580383300781, ""Name"": ""Clarion Hotel Tyholmen"" }, { ""Lon"": 7.99265623092651, ""Lat"": 58.1443710327148, ""Name"": ""Clarion Hotel Ernst"" }, { ""Lon"": 10.9997596740723, ""Lat"": 59.9792785644531, ""Name"": ""Quality Hotel Olavsgaard"" }, { ""Lon"": 10.2574396133423, ""Lat"": 60.1664390563965, ""Name"": ""Comfort Hotel Ringerike"" }, { ""Lon"": 10.6905498504639, ""Lat"": 60.7966194152832, ""Name"": ""Comfort Hotel Grand"" }, { ""Lon"": 10.0292100906372, ""Lat"": 59.0509910583496, ""Name"": ""Quality Hotel Grand Farris"" }, { ""Lon"": 5.85072708129883, ""Lat"": 61.4499282836914, ""Name"": ""Quality Hotel Førde"" }, { ""Lon"": 9.649528, ""Lat"": 59.669231, ""Name"": ""Quality Hotel Grand, Kongsberg"" }, { ""Lon"": 11.496648799999999, ""Lat"": 64.013864, ""Name"": ""Quality Hotel Grand, Steinkjer"" }, { ""Lon"": 8.49645328521729, ""Lat"": 59.3249206542969, ""Name"": ""Quality Straand Hotel & Resort"" }, { ""Lon"": 5.0283989906311, ""Lat"": 61.6004791259766, ""Name"": ""Quality Hotel Florø"" }, { ""Lon"": 9.23723983764648, ""Lat"": 60.9852485656738, ""Name"": ""Quality Hotel & Resort Fagernes"" }, { ""Lon"": 10.7384700775146, ""Lat"": 59.9166984558105, ""Name"": ""Clarion Collection Hotel Savoy"" }, { ""Lon"": 7.09996223449707, ""Lat"": 61.2304000854492, ""Name"": ""Quality Hotel Sogndal"" }, { ""Lon"": 16.5495891571045, ""Lat"": 68.8042373657227, ""Name"": ""Clarion Collection Hotel Arcticus"" }, { ""Lon"": 18.9577503204346, ""Lat"": 69.6480865478516, ""Name"": ""Quality Hotel Saga"" }, { ""Lon"": 7.99096822738647, ""Lat"": 58.1458511352539, ""Name"": ""Comfort Hotel Kristiansand"" }, { ""Lon"": 11.0748100280762, ""Lat"": 60.7932510375977, ""Name"": ""Quality Hotel Astoria"" }, { ""Lon"": 11.0696802139282, ""Lat"": 60.1926612854004, ""Name"": ""Clarion Hotel & Congress Oslo Airport"" }, { ""Lon"": 5.73533010482788, ""Lat"": 58.9701194763184, ""Name"": ""Comfort Hotel Stavanger"" }, { ""Lon"": 14.3779897689819, ""Lat"": 67.2839126586914, ""Name"": ""Clarion Collection Hotel Grand Bodø"" }, { ""Lon"": 7.73146486282349, ""Lat"": 63.1123008728027, ""Name"": ""Comfort Hotel Fosna"" }, { ""Lon"": 7.15436220169067, ""Lat"": 62.7357292175293, ""Name"": ""Comfort Hotel Nobel"" }, { ""Lon"": 10.4654598236084, ""Lat"": 59.8316307067871, ""Name"": ""Quality Hotel Leangkollen"" }, { ""Lon"": 11.0632431, ""Lat"": 59.2958142, ""Name"": ""Quality Hotel & Resort Sarpsborg"" }, { ""Lon"": 5.72849580000002, ""Lat"": 58.9676423, ""Name"": ""Clarion Hotel Stavanger"" }, { ""Lon"": 14.1340398788452, ""Lat"": 66.3128509521484, ""Name"": ""Comfort Hotel Ole Tobias"" }, { ""Lon"": 18.9585094451904, ""Lat"": 69.6499633789063, ""Name"": ""Clarion Hotel Bryggen"" }, { ""Lon"": 7.06979894638062, ""Lat"": 60.4674797058105, ""Name"": ""Quality Hotel & Resort Vøringfoss"" }, { ""Lon"": 7.15430688858032, ""Lat"": 62.7348403930664, ""Name"": ""Quality Hotel Alexandra"" }, { ""Lon"": 7.73102378845215, ""Lat"": 63.1099281311035, ""Name"": ""Quality Hotel Grand, Kristiansund"" }, { ""Lon"": 9.61240482330322, ""Lat"": 59.2052116394043, ""Name"": ""Clarion Collection Hotel Bryggeparken"" }, { ""Lon"": 10.4078397750854, ""Lat"": 59.2647705078125, ""Name"": ""Quality Hotel Tønsberg"" }, { ""Lon"": 10.3925399780273, ""Lat"": 63.4275894165039, ""Name"": ""Comfort Hotel Park"" }, { ""Lon"": 10.4145603179932, ""Lat"": 59.5414199829102, ""Name"": ""Quality Spa & Resort Holmsbu"" }, { ""Lon"": 10.7090501785278, ""Lat"": 59.9136505126953, ""Name"": ""Clarion Collection Hotel Gabelshus"" }, { ""Lon"": 10.745400428772, ""Lat"": 59.9081993103027, ""Name"": ""Clarion Collection Hotel Bastion"" }, { ""Lon"": 5.32130002975464, ""Lat"": 60.3978996276855, ""Name"": ""Clarion Collection Hotel Havnekontoret"" }, { ""Lon"": 5.23088312149048, ""Lat"": 60.2904891967773, ""Name"": ""Clarion Hotel Bergen Airport"" }, { ""Lon"": 17.4333305358887, ""Lat"": 68.4404678344727, ""Name"": ""Quality Hotel Grand Royal"" }, { ""Lon"": 5.84689998626709, ""Lat"": 62.342601776123, ""Name"": ""Quality Hotel Ulstein"" }, { ""Lon"": 10.818510055542, ""Lat"": 59.9288482666016, ""Name"": ""Quality Hotel 33"" }, { ""Lon"": 10.7494697570801, ""Lat"": 59.916431427002, ""Name"": ""Comfort Hotel Xpress, Oslo"" }, { ""Lon"": 10.4022197723389, ""Lat"": 63.432918548584, ""Name"": ""Comfort Hotel Trondheim"" }, { ""Lon"": 10.6841602325439, ""Lat"": 59.5170211791992, ""Name"": ""Quality Spa & Resort Son"" }, { ""Lon"": 9.51984310150146, ""Lat"": 60.2271881103516, ""Name"": ""Quality Spa & Resort Norefjell"" }, { ""Lon"": 5.03527784347534, ""Lat"": 61.5997200012207, ""Name"": ""Comfort Hotel Florø"" }, { ""Lon"": 10.7508697509766, ""Lat"": 59.9139709472656, ""Name"": ""Clarion Collection Hotel Folketeateret"" }, { ""Lon"": 10.4041996002197, ""Lat"": 59.2681007385254, ""Name"": ""Quality Hotel Klubben"" }, { ""Lon"": 11.0718898773193, ""Lat"": 60.1931800842285, ""Name"": ""Comfort Hotel RunWay"" }, { ""Lon"": 5.72681713104248, ""Lat"": 58.9692192077637, ""Name"": ""Comfort Hotel Square"" }, { ""Lon"": 10.1921901702881, ""Lat"": 59.7436904907227, ""Name"": ""Comfort Hotel Union Brygge"" }, { ""Lon"": 10.9391202926636, ""Lat"": 59.2112312316895, ""Name"": ""Quality Hotel Fredrikstad"" }, { ""Lon"": 10.6937303543091, ""Lat"": 60.7949905395508, ""Name"": ""Quality Hotel Strand"" }, { ""Lon"": 6.1463418006897, ""Lat"": 62.4700889587402, ""Name"": ""Quality Hotel Waterfront"" }, { ""Lon"": 10.4026403427124, ""Lat"": 63.4393005371094, ""Name"": ""Clarion Hotel & Congress Trondheim"" }, { ""Lon"": 10.6287403106689, ""Lat"": 59.9019088745117, ""Name"": ""Quality Hotel Expo"" }, { ""Lon"": 10.7507295608521, ""Lat"": 59.9108695983887, ""Name"": ""Comfort Hotel Grand Central"" }, { ""Lon"": 10.0201902389526, ""Lat"": 59.0498809814453, ""Name"": ""Farris Bad"" }, { ""Lon"": 17.8959197998047, ""Lat"": 59.6079216003418, ""Name"": ""Quality Airport Hotel Arlanda"" }, { ""Lon"": 14.1901998519897, ""Lat"": 57.7586898803711, ""Name"": ""Quality Hotel Jønkøping"" }, { ""Lon"": 15.2059497833252, ""Lat"": 59.2962417602539, ""Name"": ""Quality Hotel Ã–rebro"" }, { ""Lon"": 12.9089202880859, ""Lat"": 56.6536903381348, ""Name"": ""Quality Hotel Halmstad"" }, { ""Lon"": 18.0865001678467, ""Lat"": 59.34375, ""Name"": ""Clarion Collection Hotel Tapto"" }, { ""Lon"": 20.26535987854, ""Lat"": 63.8241310119629, ""Name"": ""Clarion Collection Hotel Uman"" }, { ""Lon"": 12.2466402053833, ""Lat"": 57.1077995300293, ""Name"": ""Clarion Collection Hotel Fregatten"" }, { ""Lon"": 13.8506603240967, ""Lat"": 58.3907508850098, ""Name"": ""Clarion Collection Hotel Majoren"" }, { ""Lon"": 16.4496307373047, ""Lat"": 57.264720916748, ""Name"": ""Clarion Collection Hotel Post"" }, { ""Lon"": 17.0156307220459, ""Lat"": 58.7483406066895, ""Name"": ""Clarion Collection Hotel Kompaniet"" }, { ""Lon"": 13.5086443, ""Lat"": 59.3794437, ""Name"": ""Clarion Collection Hotel Bilan"" }, { ""Lon"": 16.3663291931152, ""Lat"": 56.6608810424805, ""Name"": ""Clarion Collection Hotel Packhuset"" }, { ""Lon"": 14.1609401702881, ""Lat"": 57.7825508117676, ""Name"": ""Clarion Collection Hotel Victoria"" }, { ""Lon"": 16.5117893218994, ""Lat"": 59.3763999938965, ""Name"": ""Clarion Collection Hotel Bolinder Munktell"" }, { ""Lon"": 11.9879503250122, ""Lat"": 57.6896095275879, ""Name"": ""Quality Hotel Panorama, Gothenburg"" }, { ""Lon"": 13.0011901855469, ""Lat"": 55.6107711791992, ""Name"": ""Comfort Hotel Malmø"" }, { ""Lon"": 18.0543804168701, ""Lat"": 59.3330612182617, ""Name"": ""Comfort Hotel Stockholm"" }, { ""Lon"": 14.15339469, ""Lat"": 56.03242947, ""Name"": ""Quality Hotel Grand, Kristianstad"" }, { ""Lon"": 11.9137496948242, ""Lat"": 57.7013702392578, ""Name"": ""Quality Hotel 11"" }, { ""Lon"": 13.0078401565552, ""Lat"": 55.5993614196777, ""Name"": ""Quality Hotel Konserthuset"" }, { ""Lon"": 15.6241302490234, ""Lat"": 58.405818939209, ""Name"": ""Quality Hotel Ekoxen"" }, { ""Lon"": 18.1183109283447, ""Lat"": 59.3067588806152, ""Name"": ""Quality Hotel Nacka"" }, { ""Lon"": 17.9090003967285, ""Lat"": 59.2732200622559, ""Name"": ""Quality Hotel Prince Philip"" }, { ""Lon"": 18.0850310000001, ""Lat"": 59.2934929, ""Name"": ""Quality Hotel Globe"" }, { ""Lon"": 11.8073797225952, ""Lat"": 58.0644493103027, ""Name"": ""Stenungsbaden Yacht Club"" }, { ""Lon"": 13.1291999816895, ""Lat"": 59.828239440918, ""Name"": ""Selma Spa+"" }, { ""Lon"": 13.1347599029541, ""Lat"": 59.8274612426758, ""Name"": ""Quality Hotel Selma Lagerløf"" }, { ""Lon"": 11.9810304641724, ""Lat"": 57.730899810791, ""Name"": ""Quality Hotel Winn Gøteborg"" }, { ""Lon"": 12.6999998092651, ""Lat"": 56.0410308837891, ""Name"": ""Comfort Hotel Nouveau"" }, { ""Lon"": 12.3178596496582, ""Lat"": 58.3635902404785, ""Name"": ""Quality Hotel VÃ¤nersborg"" }, { ""Lon"": 16.5456600189209, ""Lat"": 59.6100006103516, ""Name"": ""Clarion Collection Hotel Etage"" }, { ""Lon"": 15.4303398132324, ""Lat"": 60.4885406494141, ""Name"": ""Quality Hotel Galaxen"" }, { ""Lon"": 14.8317604064941, ""Lat"": 56.8799209594727, ""Name"": ""Quality Hotel VÃ¤xjø"" }, { ""Lon"": 22.147017, ""Lat"": 65.5837716, ""Name"": ""Quality Hotel Luleå"" }, { ""Lon"": 12.9987497329712, ""Lat"": 55.6038513183594, ""Name"": ""Clarion Collection Hotel Temperance"" }, { ""Lon"": 13.4990711, ""Lat"": 59.3787483, ""Name"": ""Clarion Collection Hotel Drott"" }, { ""Lon"": 18.0749397277832, ""Lat"": 59.3075408935547, ""Name"": ""Clarion Hotel Stockholm"" }, { ""Lon"": 12.9215402603149, ""Lat"": 59.1304397583008, ""Name"": ""Comfort Hotel Royal"" }, { ""Lon"": 16.5170097351074, ""Lat"": 59.3718490600586, ""Name"": ""Comfort Hotel Eskilstuna"" }, { ""Lon"": 18.0825595855713, ""Lat"": 59.3351707458496, ""Name"": ""Clarion Collection Hotel Wellington"" }, { ""Lon"": 13.8570191, ""Lat"": 58.3879274, ""Name"": ""Quality Hotel Prisma"" }, { ""Lon"": 17.6275596618652, ""Lat"": 59.193359375, ""Name"": ""Quality Hotel Park SødertÃ¤lje"" }, { ""Lon"": 16.5022324, ""Lat"": 59.6238229, ""Name"": ""Quality Hotel VÃ¤sterås"" }, { ""Lon"": 12.5931596755981, ""Lat"": 59.6551284790039, ""Name"": ""Comfort Hotel Bristol"" }, { ""Lon"": 12.858699798584, ""Lat"": 56.6785011291504, ""Name"": ""Clarion Collection Hotel Norre Park"" }, { ""Lon"": 11.1596698760986, ""Lat"": 58.9441184997559, ""Name"": ""Quality Spa & Resort Strømstad"" }, { ""Lon"": 11.9792003631592, ""Lat"": 57.7088012695313, ""Name"": ""Clarion Collection Hotel Odin"" }, { ""Lon"": 17.3111000061035, ""Lat"": 62.3897018432617, ""Name"": ""Clarion Collection Hotel Grand Sundsvall"" }, { ""Lon"": 11.9561500549316, ""Lat"": 57.7035217285156, ""Name"": ""Comfort Hotel City Center"" }, { ""Lon"": 12.9411001205444, ""Lat"": 57.7226982116699, ""Name"": ""Comfort Hotel Jazz"" }, { ""Lon"": 18.2908306121826, ""Lat"": 57.6384201049805, ""Name"": ""Clarion Hotel Wisby"" }, { ""Lon"": 18.0535793304443, ""Lat"": 59.334358215332, ""Name"": ""Clarion Hotel Sign"" }, { ""Lon"": 12.6939001083374, ""Lat"": 56.0462989807129, ""Name"": ""Clarion Grand Hotel Helsingborg"" }, { ""Lon"": 13.5011396408081, ""Lat"": 59.3783988952637, ""Name"": ""Clarion Hotel Plaza"" }, { ""Lon"": 15.2134504318237, ""Lat"": 59.2703399658203, ""Name"": ""Clarion Hotel Ã–rebro"" }, { ""Lon"": 17.6374492645264, ""Lat"": 59.8602104187012, ""Name"": ""Clarion Hotel Gillet"" }, { ""Lon"": 14.1563301086426, ""Lat"": 57.7789993286133, ""Name"": ""Comfort Hotel Jønkøping"" }, { ""Lon"": 14.6362895965576, ""Lat"": 63.1802291870117, ""Name"": ""Clarion Hotel Grand Ã–stersund"" }, { ""Lon"": 15.6354703903198, ""Lat"": 60.6057090759277, ""Name"": ""Clarion Collection Hotel BergmÃ¤staren"" }, { ""Lon"": 15.5905599594116, ""Lat"": 56.1669502258301, ""Name"": ""Clarion Collection Hotel Carlscrona"" }, { ""Lon"": 18.1352195739746, ""Lat"": 59.1660499572754, ""Name"": ""Quality Hotel Winn, Haninge"" }, { ""Lon"": 17.1403007507324, ""Lat"": 60.6755790710449, ""Name"": ""Clarion Hotel Winn"" }, { ""Lon"": 14.8054504394531, ""Lat"": 56.8786201477051, ""Name"": ""Clarion Collection Hotel Cardinal"" }, { ""Lon"": 20.2658100128174, ""Lat"": 63.8262596130371, ""Name"": ""Comfort Hotel Winn"" }, { ""Lon"": 18.0039291381836, ""Lat"": 59.3724594116211, ""Name"": ""Quality Hotelâ„¢ Friends"" }, { ""Lon"": 13.2154364, ""Lat"": 55.6985809, ""Name"": ""Clarion Collection Hotel Planetstaden"" }, { ""Lon"": 18.2380294799805, ""Lat"": 59.3463401794434, ""Name"": ""Yasuragi Hasseludden"" }, { ""Lon"": 18.0571308135986, ""Lat"": 59.3326187133789, ""Name"": ""Nordic Light Hotel"" }, { ""Lon"": 13.177490234375, ""Lat"": 63.3832397460938, ""Name"": ""Copperhill Mountain Lodge"" }, { ""Lon"": 18.05677754, ""Lat"": 59.33220262, ""Name"": ""Nordic Sea Hotel"" }, { ""Lon"": 5.73008140000002, ""Lat"": 58.9720275, ""Name"": ""Clarion Collection Hotel Skagen Brygge"" }, { ""Lon"": 14.9898099899292, ""Lat"": 60.8179702758789, ""Name"": ""Quality Spa & Resort Dalecarlia"" }, { ""Lon"": 25.2749290466309, ""Lat"": 54.6725807189941, ""Name"": ""Comfort Hotel LT"" }, { ""Lon"": 17.3068103790283, ""Lat"": 62.3868103027344, ""Name"": ""Quality Hotel Sundsvall"" }, { ""Lon"": 22.1637191772461, ""Lat"": 65.5830230712891, ""Name"": ""Comfort Hotel Arctic"" }, { ""Lon"": 12.6961603164673, ""Lat"": 56.0477409362793, ""Name"": ""Clarion Collection Hotel Helsing"" }, { ""Lon"": 10.7215204238892, ""Lat"": 59.9076194763184, ""Name"": ""THE THIEF"" }, { ""Lon"": 21.6875705718994, ""Lat"": 65.8254470825195, ""Name"": ""Quality Hotel Bodensia"" }, { ""Lon"": 20.9508590698242, ""Lat"": 64.7505569458008, ""Name"": ""Quality Hotel Skellefteå Stadshotell"" }, { ""Lon"": 18.9579745999999, ""Lat"": 69.6473136, ""Name"": ""Clarion Hotel The Edge"" }, { ""Lon"": 12.9764604568481, ""Lat"": 55.5617599487305, ""Name"": ""Quality Hotel View"" }, { ""Lon"": 5.32309103012085, ""Lat"": 60.3924407958984, ""Name"": ""Clarion Collection Hotel No 13"" }, { ""Lon"": 5.69959940000001, ""Lat"": 58.9472724, ""Name"": ""Clarion Hotel Energy"" }, { ""Lon"": 18.04529, ""Lat"": 59.331329, ""Name"": ""Clarion Hotel Amaranten"" }, { ""Lon"": 12.5597295761108, ""Lat"": 55.6728515625, ""Name"": ""Comfort Hotel Vesterbro"" }, { ""Lon"": 22.1509895324707, ""Lat"": 65.5850219726563, ""Name"": ""Clarion Hotel Sense"" }, { ""Lon"": 10.7358512000001, ""Lat"": 59.9135549, ""Name"": ""Clarion Collection Hotel Christiania Teater"" }, { ""Lon"": 17.9301605224609, ""Lat"": 59.6489906311035, ""Name"": ""Clarion Hotel Arlanda Airport"" }, { ""Lon"": 11.9745399999999, ""Lat"": 57.70792, ""Name"": ""Clarion Hotel Post"" }, { ""Lon"": 19.1762989, ""Lat"": 65.5952349, ""Name"": ""Clarion Collection Hotel Arvidsjaur"" }, { ""Lon"": 12.57191, ""Lat"": 55.680679, ""Name"": ""SKT. PETRI"" } ]";

        private static RootObj[] JsonObj;
        //private static dynamic ;

        private static void Main(string[] args)
        {
            var sxNrOfHotels = 0;
            var sxNrOfLatLonMatches = 0;
            var sxNrOfLatLonSkips = 0;
            var nomatch = new List<string>();

            try
            {
                JsonObj = new JavaScriptSerializer().Deserialize<RootObj[]>(JsonText);
                //foreach (var obj in JsonObj.objectList)
                //{
                //    Console.WriteLine(obj.address);
                //}


                var db = new ChoiceCenium_dbEntities();
                
                if (args.Length != 1)
                    Console.WriteLine("Please specify 'Filename'");

                string filename = args[0];

                var fs = new FileStream(filename, FileMode.Open);

                var hotelData = HotelImport.ReadHotel(fs);
                hotelData = hotelData.Where(hd => !String.IsNullOrEmpty(hd.HotelName)).ToList();
                //hotelData = hotelData.Distinct(new EqualityComparer()).ToList();

                //var distinctKjeder = hotelData.Select(hd => hd.Kjede).Distinct().ToList();

                //foreach (var kj in distinctKjeder)
                //{
                //    var kjedeNavn = "";
                    
                //    if (kj == "Nordic Resorts" || kj == "Nordic Hotels")
                //    {
                //        kjedeNavn = "Nordic Hotels & Resorts";
                //    }
                //    else
                //    {
                //        kjedeNavn = kj;
                //    }
                //    db.KjedeInfoes.Add(new KjedeInfoes {KjedeNavn = kjedeNavn});
                //}

                //db.KjedeInfoes.AddRange(distinctKjeder.Select(k => new KjedeInfoes {KjedeNavn = k}));
                //db.SaveChanges();


                

                foreach (var hd in hotelData)
                {
                    // UGLER ER FINE:
                    var lon = "";
                    var lat = "";
                    

                    LonLat lonlat = TryMatchHotelNameVSJSONList(hd.HotelName);
                    lon = lonlat.Lon;
                    lat = lonlat.Lat;
                    if (lon != "")
                    {
                        sxNrOfLatLonMatches++;
                    }
                    else
                    {
                        sxNrOfLatLonSkips++;
                        nomatch.Add(lonlat.HotelNameSource);
                    }

                    var hotelInfo = new Hotelinfoes
                    {
                        HotelName = hd.HotelName,
                        Address = hd.Address,
                        KjedeInfoes = db.KjedeInfoes.Single(k => k.KjedeId == 61),
                        NotUpgrading = hd.NotUpgrading,
                        UpgradeDate = null,
                        Lon = lon,
                        Lat = lat
                    };
                    db.Hotelinfoes.Add(hotelInfo);
                    sxNrOfHotels++;
                    db.SaveChanges();
                }

            }
            finally
            {
                Console.WriteLine("Finished!");
                Console.WriteLine("Antall hoteller importert: " + sxNrOfHotels);
                Console.WriteLine("Antall LonLat matches: " + sxNrOfLatLonMatches);
                Console.WriteLine("Antall LonLat skips: " + sxNrOfLatLonSkips);

                foreach (string str in nomatch)
                {
                    Console.WriteLine(str);
                }


                Console.ReadLine();
            }
        }

        private static LonLat TryMatchHotelNameVSJSONList(string hotelName)
        {
            foreach (var obj in JsonObj)
            {
                if (hotelName.ToLower() == obj.Name.ToLower())
                {
                    return new LonLat{Lat = obj.Lat, Lon = obj.Lon};
                }
            }
            return new LonLat { Lat = "", Lon = "", HotelNameSource = hotelName };    
        }
    }

    public class ObjectList
    {
        public string Name { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
    }

    public class RootObj
    {
        public string Name { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        //public string objectType { get; set; }
        //public List<ObjectList> objectList { get; set; }
    }

    public class LonLat
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string HotelNameSource { get; set; }
    }

}

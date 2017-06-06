using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using DataMiner.Services;
using DataMiner.Services.Models;
using DataMiner.Services.RavenDB;

namespace DataMiner.App
{
    class Program
    {
        static void Main(string[] args)
        {
            sqlRegistrations();
        }

        public static void load()
        {
            var parser = new Parser();
            var urlBuilder = new UrlBuilder();
            var storage = new Storage();
            using (var loader = new Loader())
            {
                for (var i = 0; i < 3000; i++)
                {
                    var f = loader.Load(urlBuilder.GetNext());
                    var o = parser.Parse(f);
                    storage.Save(o);
                    foreach (var @event in o.Events)
                    {
                        storage.Save(@event);
                    }
                }
                Thread.Sleep(5000);
            }
        }

        public static void categories()
        {
            var storage = new Storage();
            var flag = true;
            var page = 0;
            var data = new List<RootObject>();
            while (flag)
            {
                var tmp = storage.Get(page);
                if (tmp.Count() != 100)
                {
                    flag = false;
                }
                page++;
               data.AddRange(tmp);
                
            }
            var cats = new List<EventCategory>();
            foreach (var rootObject in data)
            {
                foreach (var @event in rootObject.Events)
                {
                    if (@event.Category!=null && cats.All(x => x.Id != @event.Category.Id))
                    {
                        cats.Add(@event.Category);
                    }
                }
            }
            Console.WriteLine(cats.Count);
            foreach (var eventCategory in cats)
            {
                storage.Save(eventCategory);
            }
            Console.ReadKey();
        }


        public static void sqlCategories()
        {
            var storage = new Storage();
            var cats = storage.GetAllCategories();
            var sb = new StringBuilder();
            var b = new SQLInsertBuilder();
            foreach (var eventCategory in cats)
            {
                sb.Append(b.BuildCategory(eventCategory));
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }

        public static void users()
        {
            var storage = new Storage();
            var flag = true;
            var page = 0;
            var data = new List<RootObject>();
            while (flag)
            {
                var tmp = storage.Get(page);
                if (tmp.Count() != 100)
                {
                    flag = false;
                }
                page++;
                data.AddRange(tmp);

            }
            
            var users = new List<Organizer>();
            foreach (var rootObject in data)
            {
                foreach (var @event in rootObject.Events)
                {
                    if (@event.Category != null && users.All(x => x.Id != @event.Organizer.Id))
                    {
                        users.Add(@event.Organizer);
                    }
                }
            }
            Console.WriteLine(users.Count);
            foreach (var eventCategory in users)
            {
                storage.Save(eventCategory);
            }
            Console.ReadKey();
        }

        public static void sqlUsers()
        {
            var storage = new Storage();
            var users = storage.GetAllOrganizers().ToList();
            var sb = new StringBuilder();
            var b = new SQLInsertBuilder();
            var data = new List<Organizer>();
            var r= new Random();
            for (int i = 0; i < 200; i++)
            {
                var flag = false;
                Organizer org;
                while (!flag)
                {
                    org = users.ElementAt(r.Next(0, users.Count()));
                    if (org.Name!=null && !org.Name.Contains('\''))
                    {
                        users.Remove(org);
                        data.Add(org);
                        flag = true;
                    }
                }

            }
            foreach (var user in data)
            {
                sb.Append(b.BuildUser(user));
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }

        public static void sqlEvents()
        {
            var storage = new Storage();
            var events = storage.GetAllEvents().ToList();
            var sb = new StringBuilder();
            var b = new SQLInsertBuilder();
            var users = userGuids();
            var cats = getCats();
            foreach (var @event in events.Take(50))
            {
                if (@event.Category != null && @event.Category.Name != null && @event.Description.Text!=null)
                {
                    sb.Append(b.BuildEvent(@event, users, cats));
                }
            }
            string path = @"c:\31_01_2017_Events_Data.sql";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                File.WriteAllText(path, sb.ToString());
            }
            Console.ReadKey();
        }

        public static void sqlRegistrations()
        {
            var r = new Random();
            var events = eventsGuids();
            var sb = new StringBuilder();
            var b = new SQLInsertBuilder();
            foreach (var @event in events)
            {
                var c = r.Next()%30;
                var users = userGuids();
                for (int i = 0; i < c; i++)
                {
                    var ind = r.Next(users.Count);
                    var u = users[ind];
                    users.RemoveAt(ind);
                    sb.Append(b.BuildRegistration(@event, u));
                }
            }
            string path = @"c:\31_01_2017_Registrations_Data.sql";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                File.WriteAllText(path, sb.ToString());
            }
            Console.ReadKey();
        }

        public static List<string> userGuids()
        {
            var s = usersGuids.Replace("\r\n", ",");
            var a = s.Split(',');
            return a.ToList();
        }

        public static List<string> eventsGuids()
        {
            var s = eventGuids.Replace("\r\n", ",");
            var a = s.Split(',');
            return a.ToList();
        }

        public static Dictionary<string, string> getCats()
        {
            var s = cats.Replace("\r\n", "|");
            var a = s.Split('|').ToArray();
            return a.Select(s1 => s1.Split('	')).ToDictionary(pair => pair[1], pair => pair[0]);
        } 
        public const string cats = @"D487DA2F-8CC3-44AB-8086-0B9B328E6C0E	Government & Politics
39B7D1C0-D048-4197-98DF-2E4ACC79D8F1	Travel & Outdoor
3DC07C40-3EA9-4129-A8DA-5845C12E5F12	Seasonal & Holiday
F707319E-0A64-47E1-AB64-5C48E6848E0E	Film, Media & Entertainment
859F6678-5FC5-4D6A-BB33-704511C3924E	Hobbies & Special Interest
88C56265-3C29-4C61-B537-74D63EC46F7A	Science & Technology
1D1C6914-31FC-4C18-B971-8751805DC0E3	Religion & Spirituality
F1FA0614-A977-4A7F-AF60-8E705CBBF3B2	Health & Wellness
8031DF7B-2F4B-4CC5-9884-92CD8C33BEC4	Music
2787EED3-8A02-46B1-8131-A10549849A42	Charity & Causes
B557DD20-5E35-4F6F-9888-A871C028D438	Other
E4D76CE9-1A4C-40C7-8B63-A995D6CAE164	Food & Drink
59DBF8AA-5526-4583-9DD7-C351E37F7564	Family & Education
607A7421-E6CA-40F4-8E9B-D01749CD1CAA	Business & Professional
BF664864-ED93-426D-B46C-E50E7309D3CA	Home & Lifestyle
46ADE1A8-1DBB-4818-B573-E858B09322A8	Auto, Boat & Air
D3B746D6-47C5-4338-A4A9-EE6E26F71642	Community & Culture
E02991A7-98B4-462D-94C1-F3F2D98F4479	Fashion & Beauty
E5E782BC-781F-4479-A349-F9B78CF9415E	Sports & Fitness
9B8C4F26-19C0-4C34-A1FA-FED5D99DF445	Performing & Visual Arts";

        public const string eventGuids = @"A5F569DC-3681-4102-8533-0560096F42F6
287DE7EC-D3A3-4D53-90B3-09071973E1DD
38D7A654-FB51-4578-8C63-0AEAC63DEC11
C79B8C97-0B1D-4E3C-A837-1098834BAF29
8C693D33-6192-40FD-B0BE-21AAF715114D
771771D3-13B9-4C29-B3AB-21C53457442A
3BC6483D-293D-4ACA-A365-29DE2344491A
7D80B4A8-5080-4B03-A80D-3327D586E954
BE9E3164-7285-459F-ABB4-3A4334B76B68
9378AB28-DF41-47FA-9AF2-4681282B2EAC
431AC861-F8FA-4F40-B950-4E73F7001CA7
100D6510-3AC6-49E1-BA04-59A7886EBE70
7E944CE9-043B-4FA6-8B34-63C84622626E
4228772F-6556-4095-811E-64FDAB6B10AB
1034F65A-92DD-4826-A33E-667F60A51231
CBFF4253-9D3B-4F7A-8437-6AF29739DF61
0E85A24E-B446-471F-855F-6C16D16751A9
1C26A6E7-2188-4330-B5C3-813E9C2767C9
A397834F-8F66-419A-B9CE-87B871C54CC2
FA8BB810-EAF5-426D-8CD6-885AAFEE2CC1
EE2B9BBB-71F4-4934-8233-88EC9AF23637
C94E43E9-4359-4215-9F8C-8B3305AFD1D2
3893BE4F-1A81-44F2-8EE0-8E091625CC30
05B847EC-B9DC-41BF-AE1E-8E1C26447871
92923955-DBC8-4698-9BC9-9828819CE7B6
8AA87B6A-A259-44B9-AE2E-9BB44D9EF317
98DB6761-E9D6-4A53-BEEF-9CC632F037D4
54D26E21-D075-48D7-AD0F-B4A52D59EE01
4E0FB4B1-CFEB-4660-97FC-C0C085478001
5DB4E7FF-D19A-4D5B-BDA0-C33760C585AB
F099A93D-44F4-4B6A-B286-C375BFB96E92
BDF46772-2EEF-4EC3-A8C1-CA5C2942AFBB
29A6BECB-3DE4-4895-A1A2-D781C8E0B3B6
F08C9CC1-AD34-4F05-B88B-EF5E9D87D2FB
8C38FA3A-2212-41E9-8AD9-F6373C749886
554C5525-826D-4FE1-B026-FBBF338FD841
3A6D3176-3CB3-4166-A6FE-FEA0FFABD1B4
4EB4C0D5-B849-46C9-B0BE-FFE3ED51BA50";

        public const string usersGuids = @"9D6684F5-30AA-4126-B86D-010DCA83B152
B8261504-5278-4202-BE87-046E9D0AB298
D2C6F5EC-ED5A-441B-A901-056189EDAAA8
0393F01C-1D33-4951-96F2-0588D4C10AFE
5EE3B7B3-DF73-4961-8846-0615EF782B7A
EBB75D18-DC4C-4A0F-AF72-07DC9BCADD5C
7992A714-9594-4916-ACF0-0854EB0E058E
FB72A47F-343D-4C96-9F09-08B2E3CBEAF6
49FABD31-4B44-45C2-9A32-09736173BCA0
220EEF36-5F6C-4518-A487-0A3E69AC8112
0DD5C840-2FCA-46E4-9648-0A7A5D948E47
F3F29CA5-2844-4824-9143-0AEAA6521680
9843DA8C-DA20-4D52-97EA-0B0D4C915E14
043C6FD9-2749-4D22-8922-0C2BEE01B024
1E788F8F-F5B0-476C-8DDC-0E5B8F7EF6DB
A80AF98E-A8EF-4812-BB0B-0F6C6C9DE444
09886433-1027-4B84-9C10-119126F22FA7
B6592E5B-4B41-4459-82F4-11E1AF7BF5E4
E26FF63D-E639-4B60-8B2D-1225BFC84BCA
4C11BBBC-1D9A-4A0E-9CF0-1390AAEAF7B0
753BD5DA-8E89-413D-B7BD-13AC9B5DFAF3
EE8E7F51-EE4C-429E-887E-15803AB7925B
C46D73D5-863A-4687-95BB-1587ABDE9E8A
27E45549-EBF3-4383-9C20-16EA0405560F
4F949A7E-AFE0-42AE-9D8F-1961078E59A9
55888575-B2A1-4057-BD4E-1B011AA9E479
12830306-5155-4949-9751-1B48F6F29F67
5A2ADAF4-126F-4CD5-9507-1C6125FBDFA8
ED751223-CD94-4EAA-B5D4-1C6D0BEE9F54
5BCA3E1D-F2D8-457C-BC4A-1D940529D9BD
5D69263B-CC71-4E72-B107-1F00E1917A86
7CFBBDD7-65EB-45BF-9E2A-2155244B041C
DD142DAA-4E2A-4697-B22B-215717091899
DF076DB6-7DC3-4EEC-A6D8-2167868F712A
E90B0978-08D9-47B4-9A3E-26DC4A302198
5DC2BE2E-FF3B-44DD-9F00-275FF240E04C
FEE430BC-D440-4BB1-89EA-27EAF3C8906A
9251BD8D-2B57-49FA-8F9D-29E14CC49C31
41DE1287-695B-4D18-8705-2A2604280B9C
DB0F0D20-C2DF-40CF-BC76-2AE91525C432
2C9F770F-780F-427C-A11F-2B3AD3245D72
4409EFE2-8C63-4CD6-B7B2-2B75502C433A
23F3B021-9DE9-4C1E-AC95-2C0744B65880
A5E12390-1B95-4B2B-B7C0-2D0C80CE1BEA
F759D88A-C0A4-45E4-9325-2DFEF91309D5
C83C46C2-5731-4C95-9327-2E86322FFF3C
6665FFDC-D772-4728-85FC-2F9DA20ADD6D
ED1ADF78-A809-43E0-95C0-2FEBC681BC50
951B00CB-B68D-49FC-9DF1-3274D14B10EE
32E6277F-C2E0-4781-AA77-33433E710253
0359FC16-9F2C-4961-8F1B-3408967A07CD
8589A83E-7C70-4369-AC95-34CC145027A6
BE2F8A41-4D36-4B6A-B706-35A8080F3AE3
2665BC5F-61F1-49DF-8845-3E9BA2778CFB
42FD4A65-C476-4E39-B953-3EE871408896
7D124302-4642-48DD-A532-4106A9E68DC4
8E587805-044F-4B87-BEA5-422E4F813DFF
6F4D6621-9505-4B2B-A276-42DE30221363
38995887-4F17-4A6A-876B-430057386DC0
665552D2-C59E-47A6-A0E1-438CE0A10690
5FD10361-11E2-4E24-BB82-452B26EDAD00
41AAC811-630D-4874-9182-457B76DC2C9D
B096D3F6-F5DF-4E4D-88A1-4616426C9246
45437BAF-B351-4BCA-966C-475C4E513588
A7A9B3B3-70D0-4C39-841C-4A4E0D33842F
6B08B344-8F76-4645-9019-4C5BBAB5DA9C
9E3126FB-3CCF-41D1-934E-4CED8C88E494
320FC36B-097A-463C-A7D1-4EE89A1F8FF3
5ED1F123-1B90-4ACC-8193-4FC0D4F5340D
6F6B781C-7B7E-4EC3-99C1-5066B54A31DD
A4B717C8-94CF-468F-B056-51B0A355B0C4
2DBF55A9-D742-45D1-BDC5-5205BA2D155C
3B633D5D-ED2F-4E93-9113-555310C5F625
90F66F6E-77F9-4155-8A46-555BC4DF7EE8
535307E5-C61D-4ADE-B6FA-56D7026B6EAB
830536AA-2579-490F-B9D3-571C02F48C7D
3750CB2C-DBD1-49B1-8C55-57A3CA23368E
1DE863C3-8446-40E7-824F-59158A96D961
85C9554B-7A65-48E3-ADEF-59610DE62FE9
8FC8A476-8FF0-42C8-9F8F-59AB377B8EAB
4EBABC44-3332-4668-AA4C-5AC8F5C2BA4A
F75E95A6-4584-431E-B21C-5B2DACEA5AFE
C58629A6-4D2E-43DF-A74C-5ED7B96DFF1E
EE22ABAD-7222-4C6A-B278-5EDCD146D00A
84154EA8-8D51-4B10-9744-64C6099A8C2A
2737117F-743F-4B8A-AB5D-65913FB463B8
27BD3930-63B2-4186-9CEE-659DD504771D
829865FA-813B-4F1B-8D12-69EA23031B2D
B76FBACE-A38A-40A8-AF75-6AA37EFF1FF8
4426340A-5D50-45E8-8773-6AF592C91D78
9FD0A7C3-1189-4AB2-A05B-6AFACEB6A670
335345C9-13DA-4EF3-9761-6DDC128F63D2
C89AC008-55FF-42DF-A84F-7251843C787C
6FAE3EB8-A0F1-4DDD-B620-73236FF741D9
BDBA791A-97B3-4236-A0FF-7389006CE1D0
C7626FA8-81DA-4163-8915-73DDB28A8C41
370893B1-E4FC-4621-8E72-74312A2ED7B3
A3D3F2C9-1E33-4892-962F-751A47584E75
ABAB9F12-6AF9-4224-87BD-7794220C6102
2A82E3A9-1547-4B10-9B4E-7AAF688D54FA
B9597898-37AC-44BB-B74D-7B458FEA58B3
20C5BC7A-8518-49E9-9AD6-7CBA32BE61C2
8D1BC4A2-BBFC-4F8D-8B2B-7DCCF9A86650
FC73DC08-4F1E-4EC5-A04C-7E3A705A2E69
A2593AED-6BCB-4D22-8A92-823ECB2922E5
B577EE33-177C-4184-BE72-83E4AD4FE22A
A945B74B-9ADA-4273-A822-842675600245
942693A6-37F3-41A1-9DB3-878A3B450C73
977CA0C7-C636-43D3-8DB0-87FDF6266089
69F12FBD-FF8C-4FFC-9459-8B3D9307E5FD
3D8C7A04-F3AF-4185-9FD8-9054EE01EBA3
C73D03E3-D513-4F90-9EAC-909AAAB89A4A
E87ECA0B-FBB0-4455-A944-9120C78A7BC4
8D0F3C46-3FEF-4910-A03D-920728D77E4B
D2A4852B-9D80-48C8-A7EF-92F163ABB3B1
8C8C1447-18C8-4460-81D2-953250959074
3CC99ED1-E088-4939-A92E-95600E36F02F
9BC35E23-6345-4374-AF9C-981C7833BF30
78A27D15-649E-45BF-BBCC-9AC1CCA1484B
4F10FBF0-6CB5-4DF7-B431-9AD1C8FAE864
0E66023D-B3D3-4BC9-9DDC-9BE72B5CD141
8BB6C2F5-B262-43FB-BC12-9E76A1987FD8
C20F9794-EF5C-40BE-B5EB-9F3BBAC96FE8
66AED1AB-450A-44D9-B573-A16C3C9F9B62
B1164D03-314E-4B56-A132-A2D3E2D306F7
D30C7A13-1F0B-4760-93DF-A319B4C780D1
F77F473B-EE4B-4B53-ADB3-A4E211297FA0
4CADA70B-83C3-429B-BBE5-A8E6023FEAE5
36969277-6A13-4BE2-9971-AA52BC9AEBE9
FD3380DF-1B22-4252-8B2F-AAEE17CDC70F
7EC3CAD5-2C6B-4DB7-8452-ABF17A91AA22
2FE23FDE-5A7F-4AF2-B374-AC6D3F51337D
0883CA8F-2104-4CDE-BED7-ACA53428FEFC
E405350C-411A-4FD6-99C6-AD92652B91BE
8A987EDF-530C-4C84-877B-B1D42FE46DF3
029B2EBF-F3EA-49E8-855C-B24B8D686305
F65B12CD-312C-4C21-ABBB-B27928935ACA
F8D9DCCA-6701-4150-AFB2-B2BACD4FD16B
0DC8F2BA-AE04-4F57-837D-B9421FAC099E
79BBBE4A-0FDC-4106-A0B2-B94D780D8C14
871F3938-3C70-4A90-B12A-BB076D64BA96
B98F06FE-8736-48FC-8EAC-BBDAD6DBAFF8
DAD8F701-3F7E-4A07-AD32-BC5B463E2AD0
EA88A079-5250-47E3-8F9C-BD54F313402A
A4E5D8CD-E3C8-4978-BE84-BE0ADED2A43C
3B4BE089-3B18-4212-A677-BF9962718D20
C1D2F2D5-942A-43FB-B9AE-BFB69DAC934D
DD2890C8-3142-45FE-96D0-BFFD55C629C0
1FE39B03-FA17-4D8E-80FE-C1BD26818BAF
AB865FB8-C129-4D6D-9F4D-C2A61B02AB60
F5927E78-CC20-4AE0-B5FB-C4E7DFC7FC23
FBFCCD3E-CA7A-4D93-8384-C5492B002F66
FCAF3279-662C-473A-9B8A-C64F1C5C9FDE
73B2E657-6088-42F8-B2BC-C7F865B7A1A2
C95BADBD-A08B-4417-B274-C8219B381118
7EA1B1D5-2703-45AE-80D0-C8F6879103E5
CEF9D6AA-3D04-43AB-A5FA-C9A031BF5A25
C3D268F9-0BE6-4997-A37A-CAB529306A45
97C03B74-17D5-40A3-8C5B-CD03A5900365
4F7F6DD5-EB2D-4777-8823-CD26FB972C8B
EE11B066-F33C-42D1-A23D-D234D6A5E83C
500EB50C-A293-428D-B45C-D2D4C0E64464
CD27EAE2-91A2-434C-ACDA-D309DCA4BC49
38C27FB2-2B63-4A45-93B8-D41B68B48767
3409FF14-F842-4183-AF96-D4B3F67E2F8C
FABC9AD5-EC13-4C3E-A323-D4FC3FCB1D7F
55D522CB-594F-4E44-B644-D551DC1112F7
067D0B42-217A-4970-82AE-D5FDE0D7214B
EDAB1952-EE89-4DB6-ADB5-D82D58EFA804
24CCCC06-B369-4711-BB0F-D83EDAB03478
38023821-BB51-4801-AE93-D9620C4674AE
8BEA36B4-1273-411E-8F39-DAB8151942AC
0A12ECB7-FE1E-47CA-898E-DB3259FE9D75
1316A08B-96E8-4BDA-A890-DC49CEAB3635
FA5273EE-97FA-4DB6-8765-DD592EB53E9B
F0F7E3C9-89AA-40EA-B742-DD596ABB271C
01350D4E-7253-4213-B361-DD8C19C6D347
050521F3-53AD-422A-BCCB-DD8F3F761CFA
AB6B0463-92A3-4E98-907E-DE1D9343E06E
EFEA2F14-8F6C-48EE-9FBE-E26AD579519C
04E94C82-514C-4EB6-A4CB-E27DB1B7E70C
5926D84B-E2D9-48C3-A1EF-E37144380D6C
11910AA7-D1E5-483E-A929-E4B7683F223E
6EB8AE16-A36F-477D-8EA7-E594F0CCBAB0
D52ABA71-C19A-469F-A27F-E68DFEFF1EBE
52578EC0-A7CB-47A7-B310-E86064F5AF91
A49166AE-472B-4740-A709-EB8CE9A859B1
A69BEB3E-3E18-4E78-BB05-ED37407EC754
6A0E583E-0921-41CC-A741-EE29FB571415
C2ECD831-FD71-43D0-BABF-F12FF4FFFCD9
6B21D8D4-C7F8-4D03-BE13-F49BF7DA1E5E
B8D988FD-FD8F-4E01-9A72-F4E31E038DA5
E99D77B4-98D7-4001-8019-F69DA4A7053A
C6D14686-55E6-4E37-BF86-F75C1032A0D7
D6827CF1-913F-4E12-BB09-F87C0AECD28E
54F91C8B-5281-4DD7-86C6-FA458B69E4E0
98EA3612-153D-4915-9A18-FA67F453F7E4
616F566F-FAF5-4381-83E4-FCD093A02CB4
E3C2DE8F-E944-42E1-A5F4-FE172CFDA9B7
3C659D13-5B66-458F-A228-FEC5D30409D7";
    }
}

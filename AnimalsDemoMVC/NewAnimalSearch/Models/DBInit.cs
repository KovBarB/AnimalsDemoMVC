using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace NewAnimalSearch.Models
{
    public class DBInit : DropCreateDatabaseAlways<AnimalSearchDB>
    {
        protected override void Seed(AnimalSearchDB context)
        {
            base.Seed(context);

            //ADD ORGS
            var orgs = new List<Organisation>
            {
                new Organisation
                {
                    OrgId = Guid.NewGuid(),
                    Name = "Magyar Tengerimalac-védő Közhasznú Egyesület",
                    URL = "http://www.tengerimalacok.hu/",
                    About = "Tengerimalac-rajongóként 2011-ben fogalmazódott meg bennünk a gondolat, hogy létrehozzunk egy egyesületet, hogy szervezetként még többet tehessünk a rászoruló tengerimalacokért. 2012. októbertől végül hivatalosan is megalakult hazánk egyetlen, speciálisan tengerimalac-mentésre szakosodott „érdekvédelmi” szervezete."
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Rex Kutyaotthon Alapítvány",
                    URL = "http://rex.hu",
                    About = "A Rex Kutyaotthon Alapítvány 25 éve csökkenti a kóbor állatok létszámát állatmentés, állat-örökbeadás, ivartalanítás és szemléletformálás segítségével. Tizenkettő éve nyitotta meg kapuit állatvédelmi központunk, a Rex Állatsziget, ahol kutyamenhely és macskamentő állomás is működik. A megnyitás óta több mint 8000 négylábú került szerető gazdához, és az oktatóprogramunkon közel 20 000 kisdiák vett részt!"
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Szent Ferenc Állatotthon Alapítvány",
                    URL = "http://www.szentferenc.hu/agar-fajtamentes/",
                    About = "Nem csak keverékek, agarak is! A Szent Ferenc Állatotthon Alapítvány keretein belül elindult az agár-fajtamentés. Mivel egykor édesanyánk szívén viselte a fajta sorsát, és mi is köztük nőttünk fel, ezért örökségünknek érezzük a méltán híres, különleges fajta felkarolását, az árva agarak sorsának jobbra fordítását. Az elmúlt másfél évtizedben rengeteg agár fordult meg állatotthonunkban, ám most tovább megyünk, és különös figyelmet fordítunk a fajta hazánkban fellelhető egyedeire. Ezzel kívánjuk a szakmai körökön kívül is biztosítani az érdeklődőket hozzáértésünkről, és arról, hogy nálunk jó kezekben vannak a pályák elesett bajnokai. Így kívánjuk hatékonyabbá tenni mentésüket, biztos otthont jelentő bástyát építeni az agarak számára."
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Noé Állatotthon Alapítvány",
                    URL = "http://www.noeallatotthon.hu",
                    About = "Budapest legnagyobb állatotthonaként 1992 óta végezzük a bajba jutott, megkínzott, balesetet szenvedett állatok mentését. 3,5 hektáros, 2009. évtől majdnem 8 hektáros állatmenhelyünk jelenleg közel ezer kutya, cica, malac, kecske, juh, strucc, nyuszi, tengerimalac, csirke, kacsa, liba, páva, vaddisznó, mosómedve, ormányos medve, borz, ló, póni, szamár, láma, díszmadár, galamb, varjú, teknős, és szarvasmarha átmeneti, vagy - sok esetben - végleges otthona. 2012. tavaszától pedig bajba jutott főemlősöknek is segítünk."
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Futrinka Egyesület",
                    URL = "http://futrinkautca.hu/",
                    About = "Egyesületünk három fajta mentő csoporttal – magyar vizsla, német dog, tacskó – illetve egy a hátrányos helyzetű keverék kutyákon segítő csoporttal rendelkezik. Az egyes csoportok a Futrinka egyesület tagjaként – annak támogatása és védőernyője alatt – végzik önálló szakmai munkájukat. Évente összesen kb. 450 kutyának adunk új esélyt."
                },
                new Organisation
                {
                OrgId = Guid.Parse("4db0d649-5923-49d5-9636-2b5a6c61210b"),
                Name = "Érdi Civil Állatmentők",
                    URL = "https://hu-hu.facebook.com/erdicivilallatmentok/",
                    About = "",
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Sirius Állat- és Természetvédelmi Alapítvány",
                    URL = "http://www.siriusalapitvany.hu/fooldal",
                    About = "Közhasznú alapítványunkat 2005-ben jegyezték be hivatalosan, de alapító tagjai évekkel korábban kezdték állatvédelmi tevékenységüket. Mint minden állatbarát, mi sem tudtunk szó nélkül elmenni egy-egy bajba jutott élőlény mellett, magánemberként igyekeztünk sorsukat megoldani, elhelyezésükről és ellátásukról gondoskodni. Régóta működő állatmenhelyeken vállaltunk önkéntes feladatokat, például talált állatok ideiglenes elhelyezése, interneten, újságban fényképes hirdetése, közvetítés, ivartalanításra szállítás. Csakhamar azonban kutyusok és cicák serege várta a segítségünket…"
                },
                new Organisation
                {
                OrgId = Guid.Parse("9D2B0228-4D0D-4C23-8B49-01A698857709"),
                Name = "-Ismeretlen-",
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Budaörsi Állatmenhely",
                    URL = "http://www.budaorsiallatmenhely.hu",
                    About = "Egyesületünket 2001 októberében jegyezte be a Pestmegyei bíróság. Már ezt megelőzően is segítettünk sok gazdátlan kutyán. Budaörsön működött egy gyepmesteri telep, ahol- mint az országban sajnos általában- rossz körülmények között voltak a kutyák. Két hét után az elaltatás várt rájuk. Célunk az volt, hogy ez a helyzet megváltozzon. Kérésünkre-persze ezért harcolni kellett-az Önkormányzat megvásárolta a gyepmestertől a telket, és a terület hátsó felét-menhely kialakítása céljából-az Egyesület rendelkezésére bocsátotta. A terület első felén 30 kennellel működött a gyepmesteri telep. Az Önkormányzat elhelyezett egy faházat és felvett két alkalmazottat-így kezdtük el a munkát. Miután letelt a két hét karantén, nem lettek elaltatva a kutyák, hanem az állatvédők gondozták tovább és juttaták saját gazdához, illetve új gazdát kerestek nekik. Később a gyepmesteri feladatokat is az Egyesület vette át. Azóta sokat fejlődött a telep: a régi ketrecek fokozatosan eltűntek, kennelek és kifutók épültek. Külföldi segítséggel konténerek állnak a kutyák és cicák rendelkezésére.Egy állatbarát cég egy kis házat épített a kiskutyák részére, egy állatbarát hölgy pedig az idén a cicáknak építtetett kifutókat.belföldi és külföldi segítséggel a kutyák és cicák oltottak, és majdnem mind ivartalanítottak. Fontos lenne viszont a kennelek és kifutók felújítása, mert az évek során sok minden tönkrement. Minden segítséget köszönettel veszünk a menhelyi sorsa jutott állatok nevében."
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Vigyél Haza Alapítvány",
                    URL = "https://vigyelhaza.hu",
                    About = "Alapítványunk tíz éve dolgozik az Illatos úti, árva és sérült kutyák gyógyításáért, örökbefogadási esélyeinek növeléséért, gazdához juttatásáért. A kuratórium tagjai és valamennyi önkéntesünk, munkájukat kizárólag elkötelezettségből, az állatok iránt érzett szeretetből, szabadidejében végzik. Tevékenységünket, gazdálkodásunkat az Alapítvány Felügyelőbizottsága ellenőrzi.Önkénteseink ismereteik, lehetőségeik és képességeik szerint végzik szerteágazó és komoly munkájukat."
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Macskamentők Alapítvány",
                    URL = "https://www.macskamentok.hu/",
                    About = "Esély a kóbor, kidobott macskáknak!"
                },
                new Organisation
                {
                OrgId = Guid.NewGuid(),
                Name = "Mimóza Macskamentő Alapítvány",
                    URL = "http://www.nyau.hu/",
                    About = "Egyesek szerint az állatok mentése hobby.Szerintünk ennél sokkal többről van szó: életforma. Egyesek szerint, az állatok mentése tehervállalás. Szerintünk sokkal inkább adomány: valami, amit szívvel és lélekkel tudunk csinálni, valami, ami elengedhetetlenül hozzá tartozik az életünkhöz, hétköznapjainkhoz és ünnepeinkhez egyaránt, valami, ami ebben a változó világban számunkra mindig változatlan és állandó.Gyerekkorunk óta rajongunk az állatokért.Mindegy, hogy kutya, macska vagy kisegér, és mindegy, hogy szép vagy csúnyácska, hogy kedves vagy visszahúzódó.Szeretettel és csodálattal tekintünk mindegyikükre - és lenyűgöz minket a bennük rejlő csoda: az élet. Legyen bár egy állat egészséges vagy sérült, közvetlen vagy tartózkodó, mindegyikük hordoz magában értékeket és mindegyiküktől tanulhatunk az élet valamely fontos dolgáról: kitartásról, ragaszkodásról, szeretetről… Szívünk szerint minden rászoruló állatot felkarolnánk és minden általunk felkarolt állatot örökre magunk mellett tartanánk, de tudjuk, hogy sokkal többet tehetünk értük, és sokkal többnek segíthetünk, ha csak átmenetileg osztjuk meg velük az otthonunkat, és amint készen állnak rá, végleges gazdit keresünk számukra."
                },
            };
            foreach (var org in orgs)
            {
                context.Organisations.Add(org);
            }

            //ADD PHOTOS 
            //put the images in the AnimalPics folder!
            var photos = new List<Photo>
            {
                new Photo
                {
                    AnimalID = Guid.Parse("2627562a-9b4d-4f8d-a08f-0e70875bf03e"),
                    PhotoId = Guid.Parse("a8e9ddba-9a35-477b-a84d-76a43c21237c"),
                    URL = "/Content/AnimalPics/HPIM0844.jpg",
                    ContentType = "image/jpeg",
                    Title = "HPIM0844.jpg"
                },
                new Photo
                {
                    AnimalID = Guid.Parse("d6903f30-2b01-414d-b949-f78f8586856b"),
                    PhotoId = Guid.Parse("d7e246e0-3012-4fe7-b0e9-21ea1027f6a2"),
                    URL = "/Content/AnimalPics/Firefox.jpg",
                    ContentType = "image/jpeg",
                    Title = "Firefox.jpg"
                },
                new Photo
                {
                    AnimalID = Guid.Parse("d0b8643e-31bb-4a94-9a17-5883f09247a1"),
                    PhotoId = Guid.Parse("8d5bb7a2-9550-47fa-b24c-36a003a79d19"),
                    URL = "/Content/AnimalPics/28140-Brindle-and-white-Whippet-pup-and-Guinea-pig-white-background.jpg",
                    ContentType = "image/jpeg",
                    Title = "28140-Brindle-and-white-Whippet-pup-and-Guinea-pig-white-background.jpg"
                },
                new Photo
                {
                    AnimalID = Guid.Parse("d6903f30-2b01-414d-b949-f78f8586856b"),
                    PhotoId = Guid.Parse("7cdaeafc-6ef4-40fc-af51-fe80f1a607e8"),
                    URL = "/Content/AnimalPics/HamsterREX_468x362.jpg",
                    ContentType = "image/jpeg",
                    Title = "HamsterREX_468x362.jpg"
                },
                new Photo
                {
                    AnimalID = Guid.Parse("8c2452ce-ac0f-4643-b820-c417f8fa02c8"),
                    PhotoId = Guid.Parse("4be14abe-6950-4eeb-9ecd-b98d567ac8b7"),
                    URL = "/Content/AnimalPics/pig_1_web.jpg",
                    ContentType = "image/jpeg",
                    Title = "pig_1_web.jpg"
                },
            };
            foreach (var photo in photos)
            {
                context.Photos.Add(photo);
            }

            var animals = new List<Animal>
            {
                new Animal
                {
                    Type = AnimalType.Kutya,
                    Name = "Dina",
                    OrgId = Guid.Parse("4db0d649-5923-49d5-9636-2b5a6c61210b"),
                    RegisteredAtOrg = DateTime.Parse("2017-12"),
                    AgeMonth = 8,
                    AgeYear = 0,
                    About = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur non augue et nisi porttitor pretium. Mauris vel neque vitae orci luctus aliquet. Nulla facilisi. Donec in mi. Curabitur semper massa quis diam. Ut dignissim elit at nisi. Mauris nec ipsum. Nunc ac quam. Donec in diam. Phasellus tempus scelerisque justo. Aenean at elit id eros luctus malesuada. Donec magna. Nullam quis dui. Vivamus a est eu eros eleifend venenatis. Fusce arcu. Cras ipsum ante, placerat at, euismod eu, tempus eu, risus. Nulla tempus erat et ante. Sed facilisis scelerisque mauris. Morbi erat dui, congue sit amet, egestas eget, rutrum ac, lectus. Proin porttitor molestie lorem.",
                    ProtegeId = Guid.Parse("2627562a-9b4d-4f8d-a08f-0e70875bf03e")

                },
                new Animal
                {
                    Type = AnimalType.Kutya,
                    Name = "Bélus",
                    OrgId = Guid.Parse("2c6a9f80-d7f1-4255-bb27-a1395d0cf5af"),
                    RegisteredAtOrg = DateTime.Parse("2017-03"),
                    AgeMonth = 2,
                    AgeYear = 1,
                    About = "Porta, pellentesque. Ut sapien dolor Lacinia mauris quisque porta cras quisque donec nascetur, pretium habitasse torquent amet pretium consectetuer montes sociis rutrum eu mus eros congue auctor, commodo convallis. Et mollis, ipsum. Egestas tempor taciti vulputate. Vulputate. Aptent. Purus pede ornare egestas. Est fringilla cubilia taciti mi sem, parturient semper cubilia. Sapien sapien fusce vehicula class imperdiet. Facilisi senectus. Consequat nam pulvinar primis, viverra magna litora ante. Condimentum. Nulla neque posuere tempor tincidunt mollis urna venenatis consectetuer vivamus odio aptent porttitor ipsum nibh porttitor mattis senectus tincidunt sagittis adipiscing etiam bibendum sodales venenatis sed nascetur, vulputate dictum. Cras molestie Sociosqu etiam aenean montes. Tortor diam nunc ridiculus amet, cubilia sodales taciti nisi donec tempus massa venenatis cum ridiculus ornare senectus placerat cras ultricies, interdum hendrerit mi. Et aptent lectus eget dictumst faucibus vestibulum consequat vestibulum nulla maecenas. Penatibus amet Eros integer venenatis proin condimentum odio facilisis duis nonummy natoque turpis vestibulum tortor commodo iaculis litora volutpat mi. Fringilla. Dui potenti eget felis nam cum sapien penatibus arcu eget. Venenatis leo mus arcu elementum morbi porttitor lobortis lectus tortor ad ante ridiculus hymenaeos rhoncus cras potenti scelerisque leo.",
                    ProtegeId = Guid.Parse("d0b8643e-31bb-4a94-9a17-5883f09247a1")

                },
                new Animal
                {
                    Type = AnimalType.Malac,
                    Name = "Röfincsi",
                    OrgId = Guid.Parse("a9ded0cd-5f41-434f-b52c-075dd4bfdbd6"),
                    RegisteredAtOrg = DateTime.Parse("2018-01"),
                    AgeMonth = 4,
                    AgeYear = 6,
                    About = "Felis a. Augue hendrerit fermentum lectus commodo facilisis sodales. Donec sollicitudin aliquet parturient ornare mollis sem sed nam sagittis posuere netus nullam vulputate cras fames. Porta magna ullamcorper natoque primis aenean hendrerit amet natoque nunc montes. Nisl, ipsum eleifend rhoncus praesent magnis a pulvinar ipsum penatibus ipsum lorem eros dis. Curabitur. Tristique sollicitudin porttitor nam aptent etiam ipsum morbi nec volutpat ad, taciti a sapien laoreet sit tristique penatibus enim quisque venenatis magna diam fringilla nunc massa cum rhoncus ornare gravida fames facilisis hymenaeos sodales sagittis. Nostra mauris pede, hendrerit fusce. Orci eget dui ultricies, netus adipiscing ante imperdiet mollis tellus. Volutpat, leo taciti sollicitudin proin. Auctor. Sociosqu. Dictumst conubia erat suscipit aliquet feugiat risus nam amet cubilia dapibus turpis primis montes lacinia torquent hendrerit cubilia imperdiet. Vestibulum eros aliquet. Blandit convallis mus pharetra orci tempus.",
                    ProtegeId = Guid.Parse("8c2452ce-ac0f-4643-b820-c417f8fa02c8")

                },
                new Animal
                {
                    Type = AnimalType.Macska,
                    Name = "Darling",
                    OrgId = Guid.Parse("31812a94-45a0-4c73-b23e-d30ec531a913"),
                    RegisteredAtOrg = DateTime.Parse("2016-09"),
                    AgeMonth = 3,
                    AgeYear = 9,
                    About = "Ad malesuada malesuada convallis eget urna placerat quis conubia. Auctor, mattis ut fermentum netus phasellus hac laoreet magnis placerat odio primis donec natoque nunc blandit dignissim cras habitasse suspendisse aptent donec. Tristique sollicitudin porttitor nam aptent etiam ipsum morbi nec volutpat ad, taciti a sapien laoreet sit tristique penatibus enim quisque venenatis magna diam fringilla nunc massa cum rhoncus ornare gravida fames facilisis hymenaeos sodales sagittis. Nostra mauris pede, hendrerit fusce. Orci eget dui ultricies, netus adipiscing ante imperdiet mollis tellus. Volutpat, leo taciti sollicitudin proin. Auctor. Sociosqu. Dictumst conubia erat suscipit aliquet feugiat risus nam amet cubilia dapibus turpis primis montes lacinia torquent hendrerit cubilia imperdiet. Vestibulum eros aliquet. Blandit convallis mus pharetra orci tempus.",
                    ProtegeId = Guid.Parse("d6903f30-2b01-414d-b949-f78f8586856b")
                },
                new Animal
                {
                    Type = AnimalType.Hörcsög,
                    Name = "Jocó",
                    OrgId = Guid.Parse("564fe3ae-4e24-4d6a-80e4-3e9305471047"),
                    RegisteredAtOrg = DateTime.Parse("2018-04"),
                    AgeMonth = 3,
                    AgeYear = 0,
                    About = "Hymenaeos duis metus enim iaculis vulputate nec tortor suspendisse tristique inceptos. Duis consectetuer tristique taciti Interdum dui platea, dolor pellentesque hendrerit habitasse accumsan. Class hendrerit duis. Commodo magnis pharetra, bibendum commodo mollis lacus vivamus quisque erat magna. Velit augue arcu tristique id molestie rhoncus pretium eget. Et sed volutpat ornare ornare. Commodo ut Venenatis blandit porta imperdiet. Facilisi vivamus fermentum rhoncus fringilla sem posuere ultrices senectus dolor sagittis varius sem vivamus placerat quisque accumsan. Tincidunt lobortis etiam ipsum aptent. Vivamus ultricies per habitasse, non montes. Netus pulvinar diam lorem pellentesque natoque blandit dui scelerisque fames dis potenti urna laoreet phasellus proin sed potenti consequat vulputate curae; convallis porttitor pharetra montes tincidunt dapibus suscipit ornare curae; nonummy velit maecenas molestie, mi turpis libero convallis proin metus laoreet vivamus. Ultricies sem lacinia elementum pretium hymenaeos imperdiet nostra vivamus quam blandit pellentesque diam nostra mattis ridiculus penatibus, phasellus, quam. Felis a. Augue hendrerit fermentum lectus commodo facilisis sodales.",
                    ProtegeId = Guid.Parse("7cdaeafc-6ef4-40fc-af51-fe80f1a607e8")
                },
            };
            foreach (var animal in animals)
            {
                context.Animals.Add(animal);
            }

            //ADD ROLES          
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = "987", Name = "Admin" },
                new IdentityRole { Id = "786", Name = "User" }
            };
            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }            

            //INIT ADMIN
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var admin = new ApplicationUser();

            admin.UserName = "Almighty";
            admin.FirstName = "Barb";
            admin.LastName = "Admin";
            admin.Email = "bara2x@gmail.com";
            admin.OrgID = Guid.Parse("9D2B0228-4D0D-4C23-8B49-01A698857709");
            admin.Id = Guid.NewGuid().ToString();
            
            manager.Create(admin, "1Admin!");
            manager.AddToRole(admin.Id, "Admin");

            context.SaveChanges();
        }
    }
}
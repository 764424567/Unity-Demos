using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FaceMaskExample
{
    public static class ExampleDataSet
    {
        private static int index = 0;
        public static int Index
        {
            get { return index; }
        }

        public static int Length
        {
            get { return filenames.Length; }
        }

        private static string[] filenames = new string[10]{
            "face_mask1",
            "face_mask2",
            "face_mask3",
            "face_mask4",
            "face_mask5",
            "face_mask001", //刘亦菲
            "face_mask002",
            "face_mask003",
            "face_mask005",
            "face_mask006",
          //  "face_mask007"

        };

        private static Rect[] faceRcts = new Rect[10]{
            new Rect(),
            new Rect(),
            new Rect(),
            //panda
            new Rect(17, 64, 261, 205),
            //anime
            new Rect(56, 85, 190, 196),
              new Rect(56, 85, 190, 196), //刘亦菲
             //new Rect(),
              new Rect(),
               new Rect(),
                new Rect(),
                new Rect(),
           // new Rect(36, 85, 190, 196) //哈士奇
        };

        private static List<Vector2>[] landmarkPoints = new List<Vector2>[10]{
            null,
            null,
            null,
            //panda
            new List<Vector2>(){
                new Vector2(31, 136),
                new Vector2(23, 169),
                new Vector2(26, 195),
                new Vector2(35, 216),
                new Vector2(53, 236),
                new Vector2(71, 251),
                new Vector2(96, 257),
                new Vector2(132, 259),
                new Vector2(143, 263),
                //9
                new Vector2(165, 258),
                new Vector2(198, 255),
                new Vector2(222, 242),
                new Vector2(235, 231),
                new Vector2(248, 215),
                new Vector2(260, 195),
                new Vector2(272, 171),
                new Vector2(264, 135),
                //17
                new Vector2(45, 115),
                new Vector2(70, 94),
                new Vector2(97, 89),
                new Vector2(116, 90),
                new Vector2(135, 105),
                new Vector2(157, 104),
                new Vector2(176, 90),
                new Vector2(198, 86),
                new Vector2(223, 90),
                new Vector2(248, 110),
                //27
                new Vector2(148, 134),
                new Vector2(147, 152),
                new Vector2(145, 174),
                new Vector2(144, 192),
                new Vector2(117, 205),
                new Vector2(128, 213),
                new Vector2(143, 216),
                new Vector2(160, 216),
                new Vector2(174, 206),
                //36
                new Vector2(96, 138),
                new Vector2(101, 131),
                new Vector2(111, 132),
                new Vector2(114, 140),
                new Vector2(109, 146),
                new Vector2(100, 146),
                new Vector2(180, 138),
                new Vector2(186, 130),
                new Vector2(195, 131),
                new Vector2(199, 137),
                new Vector2(195, 143),
                new Vector2(185, 143),
                //48
                new Vector2(109, 235),
                new Vector2(118, 231),
                new Vector2(129, 228),
                new Vector2(143, 225),
                new Vector2(156, 227),
                new Vector2(174, 232),
                new Vector2(181, 234),
                new Vector2(173, 241),
                new Vector2(156, 245),
                new Vector2(143, 245),
                new Vector2(130, 244),
                new Vector2(117, 239),
                new Vector2(114, 235),
                new Vector2(130, 232),
                new Vector2(142, 232),
                new Vector2(157, 233),
                new Vector2(175, 236),
                new Vector2(155, 237),
                new Vector2(143, 238),
                new Vector2(130, 237)
            },
            //anime
            new List<Vector2>(){
                new Vector2(62, 179),
                new Vector2(72, 209),
                new Vector2(75, 223),
                new Vector2(81, 236),
                new Vector2(90, 244),
                new Vector2(101, 251),
                new Vector2(116, 258),
                new Vector2(129, 262),
                new Vector2(142, 268),
                new Vector2(160, 265),
                new Vector2(184, 260),
                new Vector2(202, 253),
                new Vector2(210, 247),
                new Vector2(217, 239),
                new Vector2(222, 229),
                new Vector2(225, 222),
                new Vector2(243, 191),
                //17
                new Vector2(68, 136),
                new Vector2(86, 128),
                new Vector2(104, 126),
                new Vector2(122, 131),
                new Vector2(134, 141),
                new Vector2(177, 143),
                new Vector2(191, 135),
                new Vector2(209, 132),
                new Vector2(227, 136),
                new Vector2(239, 143),
                //27
                new Vector2(153, 163),
                new Vector2(150, 190),
                new Vector2(149, 201),
                new Vector2(148, 212),
                new Vector2(138, 217),
                new Vector2(141, 219),
                new Vector2(149, 221),
                new Vector2(152, 220),
                new Vector2(155, 217),
                //36
                new Vector2(70, 182),
                new Vector2(85, 165),
                new Vector2(114, 168),
                new Vector2(122, 192),
                new Vector2(113, 211),
                new Vector2(82, 209),
                new Vector2(177, 196),
                new Vector2(189, 174),
                new Vector2(220, 175),
                new Vector2(234, 192),
                new Vector2(215, 220),
                new Vector2(184, 217),
                //48
                new Vector2(132, 249),
                new Vector2(134, 249),
                new Vector2(139, 250),
                new Vector2(144, 251),
                new Vector2(148, 251),
                new Vector2(153, 250),
                new Vector2(155, 251),
                new Vector2(154, 253),
                new Vector2(149, 257),
                new Vector2(144, 257),
                new Vector2(138, 256),
                new Vector2(133, 252),
                new Vector2(133, 250),
                new Vector2(139, 252),
                new Vector2(144, 254),
                new Vector2(148, 253),
                new Vector2(153, 251),
                new Vector2(148, 254),
                new Vector2(144, 254),
                new Vector2(139, 253),
            },
            //刘亦菲
            new List<Vector2>(){
                new Vector2(23,93),new Vector2(27,109),new Vector2(31,124),new Vector2(38,139),new Vector2(47,152),new Vector2(61,162),new Vector2(76,170),new Vector2(91,177),new Vector2(106,179),new Vector2(121,174),new Vector2(135,166),new Vector2(149,156),new Vector2(160,144),new Vector2(166,129),new Vector2(169,112),new Vector2(171,96),new Vector2(171,79),new Vector2(32,88),new Vector2(42,81),new Vector2(55,80),new Vector2(68,81),new Vector2(81,85),new Vector2(106,82),new Vector2(118,77),new Vector2(131,74),new Vector2(144,73),new Vector2(157,78),new Vector2(95,96),new Vector2(96,105),new Vector2(97,115),new Vector2(98,125),new Vector2(86,133),new Vector2(92,134),new Vector2(99,135),new Vector2(105,133),new Vector2(112,131),new Vector2(50,98),new Vector2(58,94),new Vector2(68,94),new Vector2(76,100),new Vector2(67,101),new Vector2(58,101),new Vector2(115,97),new Vector2(123,91),new Vector2(132,89),new Vector2(141,92),new Vector2(134,96),new Vector2(124,97),new Vector2(74,145),new Vector2(85,144),new Vector2(94,142),new Vector2(101,143),new Vector2(107,141),new Vector2(117,142),new Vector2(129,142),new Vector2(118,151),new Vector2(108,156),new Vector2(102,156),new Vector2(95,156),new Vector2(85,153),new Vector2(77,146),new Vector2(94,148),new Vector2(101,148),new Vector2(107,147),new Vector2(125,144),new Vector2(108,147),new Vector2(101,148),new Vector2(95,148)
            },
              null,
                null,
                  null,
                    null,
                     //哈士奇
   //                  	new List<Vector2>(){
   //         new Vector2(72, 129),
   //         new Vector2(62, 157),
   //         new Vector2(67, 179),
   //         new Vector2(79, 195),
   //         new Vector2(95, 204),
   //         new Vector2(109, 213),
   //         new Vector2(124, 217),
   //         new Vector2(136, 217),
   //         new Vector2(145, 222),
			////9 左脸
			//new Vector2(165, 258),
   //         new Vector2(174, 214),
   //         new Vector2(192, 205),
   //         new Vector2(207, 193),
   //         new Vector2(218, 180),
   //         new Vector2(228, 166),
   //         new Vector2(225, 146),
   //         new Vector2(220, 130),
			////17 脸
			//new Vector2(84, 115),
   //         new Vector2(102, 102),
   //         new Vector2(122, 96),
   //         new Vector2(137, 97),
   //         new Vector2(144, 106),
   //         new Vector2(152, 107),
   //         new Vector2(161, 96),
   //         new Vector2(178, 97),
   //         new Vector2(196, 106),
   //         new Vector2(211, 120),
			////27 眉
			//new Vector2(148, 129),
   //         new Vector2(148, 139),
   //         new Vector2(148, 149),
   //         new Vector2(147, 159),
   //         new Vector2(129, 180),
   //         new Vector2(136, 187),
   //         new Vector2(147, 190),
   //         new Vector2(160, 188),
   //         new Vector2(165, 180),
			////36 鼻子
			//new Vector2(106, 128),
   //         new Vector2(113, 122),
   //         new Vector2(123, 122),
   //         new Vector2(127, 130),
   //         new Vector2(121, 135),
   //         new Vector2(111, 134),
   //         new Vector2(172, 130),
   //         new Vector2(177, 123),
   //         new Vector2(185, 124),
   //         new Vector2(189, 132),
   //         new Vector2(184, 136),
   //         new Vector2(176, 137),
			////48 眼睛
			//new Vector2(125, 205),
   //         new Vector2(132, 202),
   //         new Vector2(140, 200),
   //         new Vector2(147, 198),
   //         new Vector2(154, 201),
   //         new Vector2(160, 203),
   //         new Vector2(168, 207),
   //         new Vector2(164, 209),
   //         new Vector2(155, 211),
   //         new Vector2(147, 212),
   //         new Vector2(140, 211),
   //         new Vector2(132, 209),
			////嘴巴
			//new Vector2(130, 206),
   //         new Vector2(137, 205),
   //         new Vector2(147, 204),
   //         new Vector2(154, 205),
   //         new Vector2(162, 206),
   //         new Vector2(154, 209),
   //         new Vector2(147, 210),
   //         new Vector2(139, 209)
   //     },

        };

        public static ExampleMaskData GetData(){
            return new ExampleMaskData(filenames[index], faceRcts[index], landmarkPoints[index]);
        }

        public static ExampleMaskData GetData(int index){
            return new ExampleMaskData(filenames[index], faceRcts[index], landmarkPoints[index]);
        }

        public static void Next(){
            index++;
            if(index == filenames.Length)
                index = 0;
        }
    }

    public class ExampleMaskData
    {
        private string filename;
        public string FileName
        {
            get { return this.filename; }
        }

        private Rect faceRect;
        public Rect FaceRect
        {
            get { return this.faceRect; }
        }

        private List<Vector2> landmarkPoints;
        public List<Vector2> LandmarkPoints
        {
            get { return this.landmarkPoints; }
        }
        
        public ExampleMaskData(string filename, Rect faceRect, List<Vector2> landmarkPoints){
            this.filename = filename;
            this.faceRect = faceRect;
            this.landmarkPoints = landmarkPoints;
        }
    }
}
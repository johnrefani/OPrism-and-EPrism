using System.Collections.Generic;
using UnityEngine;

public class QuestionData : MonoBehaviour
{
    public Dictionary<string, (string question, string questionType, List<string> answers, string answerType, int correctIndex, int choicesCount, int hintCount, string hint1Type, string hint1Content, string hint2Type, string hint2Content, string solutionType, string solutionContent, string solutionDescription)> questions = new Dictionary<string, (string, string, List<string>, string, int, int, int, string, string, string, string, string, string, string)>()
    {
        //O-PRISM
        { "O_100",
            ("What is the correct way on writing AMBULANCE in front of the vehicle?",
            "text",
            new List<string> { "AMBULANCE", "ECNALUBMA", "" },
            "text",
            1, 2, 1,
            "video", "OPrismVideos/Q1 HINT.mp4",
            "",  "",
            "image", "OPrismImage/Q1ANSWER", "")
        },
        { "O_150",
            ("Which mirror is used in supervising a store?",
            "text",
            new List<string> { "Convex Mirror", "Concave Mirror", "" },
            "text",
            0, 2, 1,
            "image", "OPrismImage/Q2 HINT1",
            "", "",
            "image", "light bulb_icon", "Wide View: Convex mirrors offer a broader perspective, making them ideal for use in vehicles' rear-view mirrors, in stores for surveillance, and at road intersections for safety.")
        },
        { "O_200",
            ("OPrismImage/Q3 Q",
            "image",
            new List<string> { "INVERTED and bigger", "UPRIGHT and bigger", "" },
            "text",
            0, 2, 1,
            "image", "OPrismImage/Q3 HINT1",
            "", "",
            "video", "OPrismVideos/Q3 ANSWER.mp4", "")
        },
        { "O_250",
            ("In cleaning your teeth, which mirror should be used by the dentist?",
            "text",
            new List<string> { "OPrismImage/Q4 A", "OPrismImage/Q4 B", "" },
            "image",
            1, 2, 1,
            "video", "OPrismVideos/Q4 hint.mp4",
            "", "",
            "image", "OPrismImage/Q4 ANSWER", "")
        },
        { "O_300",
            ("What type of mirror will be used if we want the image and object to be the same size and same orientation?",
            "text",
            new List<string> { "Plane Mirror", "Convex Mirror", "Concave Mirror" },
            "text",
            0, 3, 2,
            "video", "OPrismVideos/Q5 HINT 1.mp4",
            "video", "OPrismVideos/Q5 HINT 2.mp4",
            "image", "OPrismImage/Q5 ANSWER", "")
        },
        { "O_350",
            ("Which lens is used to correct nearsightedness (myopia)?",
            "text",
            new List<string> { "OPrismImage/Q6 A", "OPrismImage/Q6 B", "" },
            "image",
            1, 2, 1,
            "video", "OPrismVideos/Q6 HINT 1.mp4",
            "", "",
            "image", "OPrismImage/Q6 ANSWER", "")
        },
        { "O_400",
            ("A photocopying machine produces an image that is the same size. What kind of lens or mirror?",
            "text",
            new List<string> { "Concave Lens", "Convex Mirror", "Convex Lens" },
            "text",
            2, 3, 2,
            "video", "OPrismVideos/Q7 HINT 1.mp4",
            "image", "OPrismImage/Q7 HINT2",
            "video", "OPrismVideos/Q7 ANSWER.mp4", "")
        },
        { "O_450",
            ("This lens always gives a smaller image and is always upright?",
            "text",
            new List<string> { "OPrismImage/Q8 A", "OPrismImage/Q8 B", "" },
            "image",
            1, 2, 1,
            "image", "OPrismImage/Q8 HINT",
            "", "",
            "video", "OPrismVideos/Q8 ANSWER.mp4", "")
        },
        { "O_500",
            ("OPrismImage/Q9 Q",
            "image",
            new List<string> { "Virtual, Inverted, and Smaller", "Real, inverted and smaller", "Virtual, erect and bigger" },
            "text",
            1, 3, 2,
            "video", "OPrismVideos/Q9 HINT 1.mp4",
            "image", "OPrismImage/Q9 HINT2",
            "image", "OPrismImage/Q9 ANSWER", "")
        },
        { "O_550",
            ("OPrismImage/Q10 Q",
            "image",
            new List<string> { "Virtual, upright and bigger", "Real, inverted and bigger", "Virtual, inverted and bigger" },
            "text",
            0, 3, 2,
            "image", "OPrismImage/Q10 HINT 1",
            "video", "OPrismVideos/Q10 HINT 2.mp4",
            "image", "OPrismImage/Q10 ANSWER", "")
        },
        { "O_600",
            ("A pencil is placed 25 cm from the concave lens with a 5 cm focal length. What is the resulting image?",
            "text",
            new List<string> { "Virtual, upright, and smaller", "Real, inverted and smaller", "Virtual, erect and bigger" },
            "text",
            0, 3, 2,
            "video", "OPrismVideos/Q11 HINT 1.mp4",
            "image", "OPrismImage/Q11 HINT2",
            "image", "OPrismImage/Q11 ANSWER", "")
        },
        { "O_650",
            ("Which of the following instruments forms a magnified, virtual, and upright image?",
            "text",
            new List<string> { "Camera", "Endoscope", "Microscope" },
            "text",
            2, 3, 2,
            "image", "OPrismImage/Q12 HINT 1",
            "image", "OPrismImage/Q12 HINT 2",
            "image", "OPrismImage/Q12 ANSWER", "")
        },
        { "O_700",
            ("Which lens is used in a telescope and microscope?",
            "text",
            new List<string> { "OPrismImage/Q13 A", "OPrismImage/Q13 B", "" },
            "image",
            0, 2, 1,
            "video", "OPrismVideos/Q13 HINT 1.mp4",
            "", "",
            "video", "OPrismVideos/Q13 ANSWER.mp4", "")
        },
        { "O_750",
            ("A device used to view large objects at very far distances.",
            "text",
            new List<string> { "Camera", "Periscope", "Telescope" },
            "text",
            2, 3, 2,
            "image", "OPrismImage/Q14 HINT 1",
            "image", "OPrismImage/Q14 HINT 2",
            "video", "OPrismVideos/Q14 ANSWER.mp4", "")
        },
        { "O_800",
            ("Lens can correct some eye defects. Which is used to correct myopia (nearsightedness)?",
            "text",
            new List<string> { "Concave Lens", "Convex Lens", "" },
            "text",
            0, 2, 1,
            "image", "OPrismImage/Q15 HINT 1",
            "", "",
            "image", "light bulb_icon", "Myopia causes distant objects to appear blurry. Nearsighted people use concave lenses to correct their vision. These lenses, thinner at the center and thicker at the edges, diverge light rays so they focus on the retina instead of in front of it.\r\n\r\n\r\n\r\n\r\n\r\n\r\n")
        },

        //E-PRISM
        { "E_100",
            ("EPrismImage/Q1",
            "image",
            new List<string> { "N-N", "N-S", "" },
            "text",
            1, 2, 1,
            "image", "EPrismImage/Q1 Hint1",
            "",  "",
            "video", "EPrismVideos/Q1 ANSWER.mp4", "")
        },
        { "E_150",
            ("EPrismImage/Q2",
            "image",
            new List<string> { "Same poles", "Opposite poles", "" },
            "text",
            0, 2, 1,
            "video", "EPrismVideos/Q2 Hint.mp4",
            "",  "",
            "video", "EPrismVideos/Q2 Answer.mp4", "")
        },
        { "E_200",
            ("EPrismImage/Q3",
            "image",
            new List<string> { "Magnetic field lines exist around a current carrying wire", "Magnetic field lines exist around wires even without current", "" },
            "text",
            0, 2, 1,
            "video", "EPrismVideos/Q3 Hint.mp4",
            "",  "",
            "video", "EPrismVideos/Q3 Answer.mp4", "")
        },
        { "E_250",
            ("What happens to the Magnetic field around current carrying wire when we turned off the circuit?",
            "text",
            new List<string> { "The magnetic field continue to exist", "The magnetic field gradually stop", "" },
            "text",
            1, 2, 1,
            "video", "EPrismVideos/Q4 HINT.mp4",
            "",  "",
            "video", "EPrismVideos/Q4 Answer.mp4", "")
        },
        { "E_300",
            ("Device that converts electrical energy to mechanical energy ",
            "text",
            new List<string> { "Generator", "Transformer", "Electric Motor" },
            "text",
            2, 3, 1,
            "image", "EPrismImage/Q5 Hint 1",
            "video", "EPrismVideos/Q5 Hint 2.mp4",
            "video", "EPrismVideos/Q5 Answer.mp4", "")
        },
        { "E_350",
            ("Which of this ways that can make your electro magnet powerful?",
            "text",
            new List<string> { "Minimizing power supply", "Increasing number of turns of coil", "Minimizing Magnetic field" },
            "text",
            1, 3, 1,
            "video", "EPrismVideos/Q6  Hint 1.mp4",
            "video", "EPrismVideos/Q6  Hint 2.mp4",
            "video", "EPrismVideos/Q6 Answer.mp4", "")
        },
        { "E_400",
            ("Michael Faraday Discover Electromagnetic Induction, which is the correct reperesenation of electromagnetic induction?",
            "text",
            new List<string> { "Magnet and coil of wire only", "Magnet and coil of wire and battery", "" },
            "text",
            0, 2, 1,
            "video", "EPrismVideos/Q7 Hint 1.mp4",
            "",  "",
            "video", "EPrismVideos/Q7 Answer.mp4", "")
        },
        { "E_450",
            ("Electromagnetic induction discover by Michael Faraday simply state that in a changing magnetic field can produce an induced current.",
            "text",
            new List<string> { "True", "False", "No change of magnetic field" },
            "text",
            2, 3, 1,
            "video", "EPrismVideos/Q8 Hint 1.mp4",
            "video", "EPrismVideos/Q8 Hint 1.mp4",
            "video", "EPrismVideos/Q8 Answer.mp4", "")
        },
        { "E_500",
            ("Which is not a factor that affects the induced current through a conductor by electromagnetic induction.",
            "text",
            new List<string> { "Number of coil or turs of wire", "Strength of magnetic Field", "Slow rate of magnetic field" },
            "text",
            2, 3, 1,
            "video", "EPrismVideos/Q9 Hint 1.mp4",
            "video", "EPrismVideos/Q9 Hint 2.mp4",
            "video", "EPrismVideos/Q9 Answer.mp4", "")
        },
        { "E_550",
            ("The device that converts mechanical energy to electric energy.",
            "text",
            new List<string> { "Generator", "Electric motor", "" },
            "text",
            0, 2, 1,
            "video", "EPrismVideos/Q10 Hint 1.mp4",
            "",  "",
            "video", "EPrismVideos/Q10 Answer.mp4", "")
        }
    };
}



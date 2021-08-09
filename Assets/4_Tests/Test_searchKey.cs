using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MySearchKey;
using MyChord;


namespace Tests
{
    //public class NewTestScript
    public class test_search_key
    {
        /*
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
*/

        Chord m_reference_chord;
        search_key m_target_object;

        [SetUp]
        public void Setup()
        {
            m_target_object = new search_key();

            m_reference_chord = new Chord();
        }


        [Test]
        public void four()
        {
            m_reference_chord.init("C", "C", "E", "G");

            // input
            List<string> mykey = new List<string>();

            mykey.Add("C4");
            mykey.Add("E4");
            mykey.Add("G4");

            // exe
            bool ans = m_target_object.isCorrect(m_reference_chord, mykey);

            // check
            Assert.IsTrue(ans);
        }

        [Test]
        public void five()
        {
            m_reference_chord.init("C", "C", "E", "G");
            // input
            List<string> mykey = new List<string>();

            mykey.Add("C5");
            mykey.Add("E5");
            mykey.Add("G5");

            // exe
            bool ans = m_target_object.isCorrect(m_reference_chord, mykey);

            // check
            Assert.IsTrue(ans);
        }

        [Test]
        public void four_one_five_two()
        {
            m_reference_chord.init("C", "C", "E", "G");
            // input
            List<string> mykey = new List<string>();

            mykey.Add("C4");
            mykey.Add("E5");
            mykey.Add("G5");

            // exe
            bool ans = m_target_object.isCorrect(m_reference_chord, mykey);

            // check
            Assert.IsTrue(ans);
        }

        [Test]
        public void four_two_five_one()
        {
            m_reference_chord.init("C", "C", "E", "G");
            // input
            List<string> mykey = new List<string>();

            mykey.Add("C4");
            mykey.Add("E4");
            mykey.Add("G5");

            // exe
            bool ans = m_target_object.isCorrect(m_reference_chord, mykey);

            // check
            Assert.IsTrue(ans);
        }

        [Test]
        public void wrong()
        {
            m_reference_chord.init("C", "C", "E", "G");

            // input
            List<string> mykey = new List<string>();

            mykey.Add("C4");
            mykey.Add("D4");
            mykey.Add("G4");

            // exe
            bool ans = m_target_object.isCorrect(m_reference_chord, mykey);

            // check
            Assert.IsFalse(ans);
        }

        [Test]
        public void one_sharp()
        {
            m_reference_chord.init("E", "E", "G#", "B");

            // input
            List<string> mykey = new List<string>();

            mykey.Add("E4");
            mykey.Add("G#4");
            mykey.Add("B4");

            // exe 
            bool ans = m_target_object.isCorrect(m_reference_chord, mykey);

            // check
            Assert.IsTrue(ans);
        }

        [Test]
        public void two_sharp()
        {
            m_reference_chord.init("B", "B", "D#", "F#");

            // input
            List<string> mykey = new List<string>();

            mykey.Add("B4");
            mykey.Add("D#4");
            mykey.Add("F#4");

            // exe
            bool ans = m_target_object.isCorrect(m_reference_chord, mykey);

            // check
            Assert.IsTrue(ans);
        }
    }
}

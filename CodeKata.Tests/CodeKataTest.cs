using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CodeKata.Tests
{
    public class CodeKataTest
    {
        const string alice = "Alice";
        const string bob = "Bob";
        const string charlie = "Charlie";

        [Test]
        public void PublishMessage()
        {
            var message = "I love the weather today.";
            var time = DateTime.Now;

            var response = CodeKata.PublishMessage(alice, message, time);

            var responseMsg = response.message;

            Assert.AreEqual(message, responseMsg);
        }

        [Test]
        public void ViewTimeline()
        {
            //Alice wants to view Bob's timeline
            List<string> bobsMessages = new List<string>()
            {
                "Darn! We lost! (2 minutes ago)",
                "Good game though. (1 minute ago)/n"
            };
            var expected = "Good game though. (1 minute ago)/nDarn! We lost! (2 minutes ago)";
            
            foreach (var m in bobsMessages)
            {
                CodeKata.PublishMessage(bob, m, DateTime.Now);
            }

            var response = CodeKata.ViewTimeline(alice, bob);

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void Following()
        {
            var charlieMsg = "I'm in New York today! Anyone wants to have a coffee? (15 seconds ago)";
            var expected = "Charlie - I'm in New York today! Anyone wants to have a coffee? (15 seconds ago)/n" +
                "/Bob - Good game though. (1 minute ago)/n" +
                "Bob - Darn! We lost!(2 minutes ago)/n" +
                "Alice - I love the weather today(5 minutes ago)";
            //charlie follows Alice & Bob

            CodeKata.PublishMessage(charlie, charlieMsg, DateTime.Now);
            CodeKata.Follow(charlie, alice);
            CodeKata.Follow(charlie, bob);
            var response = CodeKata.ViewWall(charlie);

            Assert.AreEqual(expected, response);
        }
    }
}

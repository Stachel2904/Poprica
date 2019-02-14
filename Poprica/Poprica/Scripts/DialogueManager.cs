using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class DialogueManager
    {
        #region Singleton
        private static DialogueManager main;

        public static DialogueManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new DialogueManager();
                }
                return main;
            }
        }
        #endregion

        private DialogueElement[] dialogue;
        private Decision[] decisions;
        private int index;

        private DialogueManager()
        {
            index = 0;
        }

        /// <summary>
        /// Loads a new Dialogue from the current SceneType and the DialogueEntities inside the Scene.
        /// </summary>
        public void LoadNewDialogue(DialogueEntityName[] dialogueEntities, ActionType actionType)
        {
            //create path
            string dialoguePath = "Content/XML/Dialogue/";

            Array.Sort(dialogueEntities);

            for (int i = 0; i < dialogueEntities.Length; i++)
            {
                dialoguePath += dialogueEntities[i].ToString();
            }

            dialoguePath += ".xml";

            //Load File
            XmlDocument dialogueFile = new XmlDocument();

            dialogueFile.Load(dialoguePath);

            //Get Dialogue
            XmlNode dialogueNode = null;

            foreach (XmlNode category in dialogueFile.DocumentElement)
            {
                if (category.Attributes[0].InnerText.ToUpper() == actionType.ToString())
                {
                    dialogueNode = GetRandomDialogueNode(category);
                }
            }

            if (dialogueNode == null)
            {
                throw new Exception(dialoguePath + " has no category for " + actionType.ToString());
            }

            dialogue = DeserializeDialogue(dialogueNode);
        }

        private DialogueElement[] DeserializeDialogue(XmlNode dialogueNode)
        {
            List<DialogueElement> deserializedDialogue = new List<DialogueElement>();

            foreach(XmlNode dialogueElementNode in dialogueNode.ChildNodes)
            {
                switch (dialogueElementNode.Name)
                {
                    case "statement":
                        deserializedDialogue.Add(CreateStatement(dialogueElementNode));
                        break;
                    case "decision":
                        deserializedDialogue.Add(CreateDecision(dialogueElementNode));
                        break;
                }
            }

            return deserializedDialogue.ToArray();
        }

        private Statement CreateStatement(XmlNode statementNode)
        {
            Statement createdStatement = new Statement();

            foreach(XmlNode statementElementNode in statementNode.ChildNodes)
            {
                switch (statementElementNode.Name)
                {
                    case "speaker":
                        DialogueEntityName speakerName = (DialogueEntityName) Enum.Parse(typeof(DialogueEntityName), statementElementNode.ChildNodes[0].InnerText.ToUpper());
                        createdStatement.Speakers.Add(speakerName, CreateSpeakerProberties(statementElementNode));
                        break;
                    case "text":
                        createdStatement.Message = statementElementNode.InnerText;
                        break;
                    case "jump":
                        createdStatement.NextStatement = Int32.Parse(statementElementNode.InnerText);
                        break;
                }
            }

            return createdStatement;
        }

        private SpeakerProberties CreateSpeakerProberties(XmlNode speakerNode)
        {
            SpeakerProberties createdSpeakerProberties = new SpeakerProberties();
            
            foreach(XmlNode speakerProbertyNode in speakerNode.ChildNodes)
            {
                switch (speakerProbertyNode.Name)
                {
                    case "mood":
                        createdSpeakerProberties.Mood = (MoodType)Enum.Parse(typeof(MoodType), speakerProbertyNode.InnerText.ToUpper());
                        break;
                    case "pose":
                        createdSpeakerProberties.Pose = (PoseType)Enum.Parse(typeof(PoseType), speakerProbertyNode.InnerText.ToUpper());
                        break;
                    case "position":
                        createdSpeakerProberties.Position = (PositionType)Enum.Parse(typeof(PositionType), speakerProbertyNode.InnerText.ToUpper());
                        break;
                    case "condition":
                        foreach(XmlNode condition in speakerProbertyNode)
                        {
                            if (condition.Name == "trait")
                            {
                                TraitType key = (TraitType)Enum.Parse(typeof(TraitType), condition.Attributes[0].InnerText.ToUpper());
                                int value = Int32.Parse(condition.InnerText);
                                createdSpeakerProberties.Conditions.Add(key, value);
                            }
                            else if (condition.Name == "mood")
                            {
                                TraitType key = TraitType.MOOD;
                                int value = (int)(MoodType)Enum.Parse(typeof(MoodType), condition.InnerText.ToUpper());
                                createdSpeakerProberties.Conditions.Add(key, value);
                            }
                            else if(condition.Name == "jump")
                            {
                                createdSpeakerProberties.FalseConditionJumpIndex = Int32.Parse(condition.InnerText);
                            }
                        }
                        break;
                    case "consequences":
                        foreach (XmlNode condition in speakerProbertyNode)
                        {
                            if (condition.Name == "trait")
                            {
                                TraitType key = (TraitType)Enum.Parse(typeof(TraitType), condition.Attributes[0].InnerText.ToUpper());
                                int value = Int32.Parse(condition.InnerText);
                                createdSpeakerProberties.Consequences.Add(key, value);
                            }
                            else if (condition.Name == "mood")
                            {
                                TraitType key = TraitType.MOOD;
                                int value = (int)(MoodType)Enum.Parse(typeof(MoodType), condition.InnerText.ToUpper());
                                createdSpeakerProberties.Consequences.Add(key, value);
                            }
                        }
                        break;
                }
            }

            return createdSpeakerProberties;
        }

        private Decision CreateDecision(XmlNode decisionNode)
        {
            Decision createdDecision = new Decision();

            foreach(XmlNode choice in decisionNode)
            {
                createdDecision.Choices.Add(choice.ChildNodes[0].InnerText, Int32.Parse(choice.ChildNodes[1].InnerText));
            }

            return createdDecision;
        }

        private bool CheckDialogueConditions(XmlNode conditionNode)
        {
            return true;
        }

        private XmlNode GetRandomDialogueNode(XmlNode category)
        {
            List<int> possibleDialogueIndices = new List<int>();
            int counter = 0;

            foreach (XmlNode dialogue in category.ChildNodes)
            {
                if (dialogue.ChildNodes[0].Name != "condition")
                {
                    possibleDialogueIndices.Add(counter);
                }
                else
                {
                    if (CheckDialogueConditions(dialogue.ChildNodes[0]))
                    {
                        possibleDialogueIndices.Add(counter);
                    }
                }
                counter++;
            }
            Random rdm = new Random();
            int chosenDialogueIndex = possibleDialogueIndices[rdm.Next(possibleDialogueIndices.Count)];

            return category.ChildNodes[chosenDialogueIndex];

        }

        private DialogueEntityName[] GetAllLeavingDialogueEntities()
        {
            return null;
        }

        private void Jump(int newIndex)
        {

        }

        public void Continue()
        {
            if(index + 1 >= dialogue.Length)
            {
                EndDialogue();
                return;
            }

            index++;

            Update();
        }

        private void Update()
        {

        }

        private void CheckMemories()
        {

        }

        private void EndDialogue()
        {

        }
    }
}

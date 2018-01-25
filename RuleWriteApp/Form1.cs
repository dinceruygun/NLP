using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLPEnvironment.Entities;
using Tokenizer;

namespace RuleWriteApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }



        private void Start()
        {
            this.Enabled = false;

            var data = txtWord.Text;

            if (string.IsNullOrEmpty(data)) return;
            if (data.Trim() == "") return;


            var tokenizer = new TokenizerManager(data);

            var result = tokenizer.Parse();
            SetMorphologic(result);


            tabControl1.SelectedIndex = 1;


            this.Enabled = true;
        }

        private void SetMorphologic(LineCollection result)
        {
            trwMorphologic.Nodes.Clear();

            foreach (var line in result)
            {
                var lineNode = new TreeNode(line.Text);


                foreach (var sentence in line.SentenceList)
                {
                    var sentenceNode = new TreeNode(sentence.Text);


                    foreach (var word in sentence.WordList)
                    {
                        var wordNode = new TreeNode(word.SpellWord == null ? word.Text : ($"{word.SpellWord.Text} [{word.SpellWord.Root.Text}]"));


                        if (word.SpellWord != null)
                        {
                            foreach (var morph in word.SpellWord.Morphologic)
                            {
                                var morphNode = new TreeNode($"[{morph.Morphologic?.Name}] {morph.Morphologic?.Description}");


                                wordNode.Nodes.Add(morphNode);
                            }
                        }


                        sentenceNode.Nodes.Add(wordNode);
                    }


                    lineNode.Nodes.Add(sentenceNode);
                }


                trwMorphologic.Nodes.Add(lineNode);
            }
        }
    }
}


#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using CodeImp.DoomBuilder.Windows;
using CodeImp.DoomBuilder.IO;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Rendering;
using CodeImp.DoomBuilder.Geometry;
using System.Drawing;
using CodeImp.DoomBuilder.Editing;
using CodeImp.DoomBuilder.Config;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
    [FindReplace("Sector Flags", BrowseButton = true, Replacable = false)]
    internal class FindSectorFlags : FindReplaceType
    {
        #region ================== Constants

        #endregion

        #region ================== Variables

        #endregion

        #region ================== Properties

        public override Image BrowseImage { get { return Properties.Resources.List; } }

        #endregion

        #region ================== Constructor / Destructor

        // Constructor
        public FindSectorFlags()
        {
            // Initialize

        }

        // Destructor
        ~FindSectorFlags()
        {
        }

        #endregion

        #region ================== Methods

        // This is called when the browse button is pressed
        public override string Browse(string initialvalue)
        {
            return FlagsForm.ShowDialog(Form.ActiveForm, initialvalue, General.Map.Config.SectorFlags);
        }


        // This is called to perform a search (and replace)
        // Returns a list of items to show in the results list
        // replacewith is null when not replacing
        public override FindReplaceObject[] Find(string value, bool withinselection, string replacewith, bool keepselection)
        {
            List<FindReplaceObject> objs = new List<FindReplaceObject>();

			// Where to search?
			ICollection<Sector> list = withinselection ? General.Map.Map.GetSelectedSectors(true) : General.Map.Map.Sectors;

            // Find what? (mxd)
            List<string> findflagslist = new List<string>();
            foreach (string flag in value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string f = flag.Trim();
                if (General.Map.Config.SectorFlags.ContainsKey(f)) findflagslist.Add(f);
            }
            if (findflagslist.Count == 0)
            {
                //MessageBox.Show("Invalid value for this search type!", "Find and Replace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return objs.ToArray();
            }

            // Go for all sectors
            foreach (Sector s in list)
            {
                bool match = true;

                // Parse the value string...
                foreach (string flag in findflagslist)
                {
                    string str = flag.Trim();

                    // ... and check if the flags don't match
                    if (General.Map.Config.SectorFlags.ContainsKey(str) && !s.IsFlagSet(str))
                    {
                        match = false;
                        break;
                    }
                }

                // Flags matches?
                if (match)
                {
                    // Add to list
                    SectorEffectInfo info = General.Map.Config.GetSectorEffectInfo(s.Effect);
                    if (!info.IsNull)
                        objs.Add(new FindReplaceObject(s, "Sector " + s.Index + " (" + info.Title + ")"));
                    else
                        objs.Add(new FindReplaceObject(s, "Sector " + s.Index));
                }
            }

            return objs.ToArray();
        }

        // This is called when a specific object is selected from the list
        public override void ObjectSelected(FindReplaceObject[] selection)
        {
            if (selection.Length == 1)
            {
                ZoomToSelection(selection);
                General.Interface.ShowSectorInfo(selection[0].Sector);
            }
            else
                General.Interface.HideInfo();

            General.Map.Map.ClearAllSelected();
            foreach (FindReplaceObject obj in selection) obj.Sector.Selected = true;
        }

        // Render selection
        public override void PlotSelection(IRenderer2D renderer, FindReplaceObject[] selection)
        {
            foreach (FindReplaceObject o in selection)
            {
                foreach (Sidedef sd in o.Sector.Sidedefs)
                {
                    renderer.PlotLinedef(sd.Line, General.Colors.Selection);
                }
            }
        }

        // Edit objects
        public override void EditObjects(FindReplaceObject[] selection)
        {
            List<Sector> sectors = new List<Sector>(selection.Length);
            foreach (FindReplaceObject o in selection) sectors.Add(o.Sector);
            General.Interface.ShowEditSectors(sectors);
        }

        #endregion
    }
}

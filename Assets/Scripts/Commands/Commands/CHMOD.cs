using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHMOD : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        if (args.Length <= 1)
        {
            return "chmod: missing operand";
        }
        else if(args.Length <= 2)
        {
            return "chmod: missing operand after '" + args[1] + "'";
        }

        // get mode
        bool add = true;
        if (args[1].Split("+").Length != 2)
        {
            if (args[1].Split("-").Length != 2)
                return "chmod: invalid mode: '" + args[1] + "'";
            else
                add = false;
        }
        

        // get requested permissions
        bool[] newPeople = { false, false, false };
        bool[] newPermissions = { false, false, false };
        string people;
        string permissions;
        if (add)
        {
            people = args[1].Split("+")[0];
            permissions = args[1].Split("+")[1];
        }
        else
        {
            people = args[1].Split("-")[0];
            permissions = args[1].Split("-")[1];
        }
        foreach (char c in people)
        {
            if (c == 'u')
                newPeople[0] = true;
            else if (c == 'g')
                newPeople[1] = true;
            else if (c == 'o')
                newPeople[2] = true;
            else
                return "chmod: invalid mode: '" + args[1] + "'";
        }
        foreach (char c in permissions)
        {
            if (c == 'r')
                newPermissions[0] = true;
            else if (c == 'w')
                newPermissions[1] = true;
            else if (c == 'x')
                newPermissions[2] = true;
            else
                return "chmod: invalid mode: '" + args[1] + "'";
        }

        // set permissions
        for (int i = 2; i < args.Length; i++)
        {
            string arg = args[i];

            bool doesExist = false;
            Folder folder = fileSystem.GetCurrentFolder();
            foreach (BaseNode node in folder.children)
            {
                if (node.name == arg)
                {
                    doesExist = true;

                    for (int j = 0; j < 3; j++)
                    {
                        if (!newPeople[j]) continue;
                        for (int k = 0; k < 3; k++)
                        {
                            if (!newPermissions[k]) continue;
                            node.permissions[j * 3 + k] = add;
                        }
                    }

                    break;
                }
            }

            if (!doesExist)
            {
                output += "chmod: cannot access '" + arg + "': No such file or directory\n";
            }
        }

        return output;
    }
}

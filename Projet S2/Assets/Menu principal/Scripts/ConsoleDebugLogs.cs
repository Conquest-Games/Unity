using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleDebugLogs : MonoBehaviour
{
    #region Jouer

    public void DebugJouer()
    {
        Debug.Log("Le joueur a cliqué sur: Jouer");
    }

    public void DebugUnJoueur()
    {
        Debug.Log("Le joueur a cliqué sur: Un Joueur");
    }

    public void DebugMultijoueur()
    {
        Debug.Log("Le joueur a cliqué sur: Multijoueur");
    }

    public void DebugRetourJouer()
    {
        Debug.Log("Le joueur a cliqué sur: Retour, dans le Menu Jouer");
    }

    #endregion

    #region Option

    public void DebugOption()
    {
        Debug.Log("Le joueur a cliqué sur: Option");
    }

    public void DebugGraphismes()
    {
        Debug.Log("Le joueur a cliqué sur: Graphismes");
    }

    public void DebugAudio()
    {
        Debug.Log("Le joueur a cliqué sur: Audio");
    }

    public void DebugConstroles()
    {
        Debug.Log("Le joueur a cliqué sur: Controles");
    }

    public void DebugRetourOption()
    {
        Debug.Log("Le joueur a cliqué sur: Retour, dans le menu Option");
    }

    #endregion

    #region Liens Externes

    public void DebugLiensExternes()
    {
        Debug.Log("Le joueur a cliqué sur: LiensExternes");
    }

    public void DebugDiscord()
    {
        Debug.Log("Le joueur a cliqué sur: Discord");
    }

    public void DebugSiteInternet()
    {
        Debug.Log("Le joueur a cliqué sur: Site Internet");
    }

    public void DebugRetourCrédit()
    {
        Debug.Log("Le joueur a cliqué sur: Retour, dans le menu Crédit");
    }

    #endregion
}

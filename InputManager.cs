using System;
using System.Collections;
using Rewired;
using UnityEngine;

// Token: 0x020003B9 RID: 953
public class InputManager : MonoBehaviour
{
	// Token: 0x06001E9F RID: 7839 RVA: 0x0008FEB4 File Offset: 0x0008E2B4
	private void Start()
	{
		Cursor.visible = false;
		player1 = ReInput.players.GetPlayer(PlayerID);
		player1.controllers.maps.SetMapsEnabled(true, ControlStyle);
		MouseControl = true;
		player1.controllers.hasKeyboard = true;
		player1.controllers.hasMouse = true;
	}

	// Token: 0x06001EA0 RID: 7840 RVA: 0x0008FF24 File Offset: 0x0008E324
	private void Update()
	{
		player1.controllers.maps.SetMapsEnabled(true, ControlStyle);
		if (!stop)
		{
			string[] joystickNames = Input.GetJoystickNames();
			for (int i = 0; i < joystickNames.Length; i++)
			{
				Debug.Log("Length " + i);
				if (!string.IsNullOrEmpty(joystickNames[i]))
				{
					Debug.Log(string.Concat(new object[]
					{
						"Controller ",
						i,
						" is connected using: ",
						joystickNames[i]
					}));
					Controllers();
				}
				else if (string.IsNullOrEmpty(joystickNames[i]))
				{
					Debug.Log("Controller: " + i + " is disconnected.");
					MouseControls();
				}
			}
		}
	}

	// Token: 0x06001EA1 RID: 7841 RVA: 0x0008FFFC File Offset: 0x0008E3FC
	private void MouseControls()
	{
		stop = true;
		StartCoroutine("ControllerCheck");
		player1.controllers.hasKeyboard = true;
		player1.controllers.hasMouse = true;
		MouseControl = true;
	}

	// Token: 0x06001EA2 RID: 7842 RVA: 0x0009003A File Offset: 0x0008E43A
	private void Controllers()
	{
		stop = true;
		StartCoroutine("ControllerCheck");
		player1.controllers.hasKeyboard = false;
		player1.controllers.hasMouse = false;
		MouseControl = false;
	}

	// Token: 0x06001EA3 RID: 7843 RVA: 0x00090078 File Offset: 0x0008E478
	public void AddControls()
	{
		ControlStyle++;
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x00090088 File Offset: 0x0008E488
	public void SubControls()
	{
		ControlStyle--;
	}

	// Token: 0x06001EA5 RID: 7845 RVA: 0x00090098 File Offset: 0x0008E498
	private IEnumerator ControllerCheck()
	{
		yield return new WaitForSecondsRealtime(2f);
		stop = false;
		yield break;
	}

	// Token: 0x040010C6 RID: 4294
	public int PlayerID;

	// Token: 0x040010C7 RID: 4295
	public Player player1;

	// Token: 0x040010C8 RID: 4296
	public bool MouseControl;

	// Token: 0x040010C9 RID: 4297
	public int ControlStyle;

	// Token: 0x040010CA RID: 4298
	private bool stop;
}

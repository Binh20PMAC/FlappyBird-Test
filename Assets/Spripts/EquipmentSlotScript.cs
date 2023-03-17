using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlotScript : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;

 
    void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0;

        transform.position = currentPosition;
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Kiểm tra xem trang bị có được kéo thả vào đúng vị trí không
        if (transform.position == startPosition)
        {
            return;
        }

        //// Lấy thông tin trang bị và tăng chỉ số cho nhân vật
        //EquipmentScript equipmentScript = GetComponentInChildren<EquipmentScript>();
        //if (equipmentScript != null)
        //{
        //    PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        //    playerStats.IncreaseStats(equipmentScript.attackBonus, equipmentScript.defenseBonus, equipmentScript.healthBonus);
        //}

        // Đặt lại vị trí của đối tượng "EquipmentSlot" về vị trí ban đầu
        transform.position = startPosition;
    }
}

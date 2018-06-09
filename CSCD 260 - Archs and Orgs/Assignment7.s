.data

	prompt: .asciiz "Assignment 7\n"

.text

main:

	li $v0, 4
	la $a0, prompt
	syscall

	lui $t0, 0xFFFF
	
	
poll:
	lw $t1, 0($t0)
	andi $t1, $t1, 1
	beq $t1, $0, poll
	lw $t1, 4($t0)
	addi $t1, $t1, 1


display:
	lw $t2, 8($t0)
	andi $t2, $t2, 1
	beq $t2, $0 display
	
	sw $t1, 12($t0)
	
	
	

li $v0, 10
syscall	


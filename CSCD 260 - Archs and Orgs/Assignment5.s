.data

	prompt1: .asciiz "Swap A and B\n"
	prompt2: .asciiz "\nA: "
	prompt3: .asciiz "\nB: "
	prompt4: .asciiz "\nAfter Swap of A and B\n"
	prompt5: .asciiz "\n\nCopying Strings \n\n"
	prompt6: .asciiz "String 1: \n"
	prompt7: .asciiz "String 2: \n"
	prompt8: .asciiz "\nBefore Copy: \n"
	prompt9: .asciiz "\nAfter copy\n"
	string: .asciiz "copy \n"
	original: .space 100
	copy: .space 100
	inta: .word 4
	intb: .word 4
	
.text

main:

	#prompt swap
	li $v0, 4
	la $a0, prompt1
	syscall

	#prompt int a
	li $v0, 4
	la $a0, prompt2
	syscall
	
	#get int a
	li $v0, 5
	syscall
	sw $v0, inta
	
	#prompt int b
	li $v0, 4
	la $a0, prompt3
	syscall
	
	#get int b
	li $v0, 5
	syscall
	sw $v0, intb

	#set stack aside
	addi $sp, $sp, -8
	la $a0, inta
	la $a1, intb
	sw $a0, 4($sp)
	sw $a1, 0($sp)

	jal swap
	addi $sp, $sp, 8
	
	#prompt AFTER swap
	li $v0, 4
	la $a0, prompt4
	syscall

	#print a 
	li $v0, 4
	la $a0, prompt2
	syscall
	lw $a0, inta
	li $v0, 1
	syscall
	
	#print b
	li $v0, 4
	la $a0, prompt3
	syscall
	lw $a0, intb
	li $v0, 1
	syscall
	
	#prompt copy
	li $v0, 4
	la $a0, prompt5
	syscall
	
	#prompt string 1
	li $v0, 4
	la $a0, prompt6
	syscall
	
	li $v0, 8
	la $a0, original
	li $a1, 100
	syscall
	
	#prompt string 2
	li $v0, 4
	la $a0, prompt7
	syscall
	
	li $v0, 8
	la $a0, copy
	li $a1, 100
	syscall
	
	#prompt before swap:
	la $a0, prompt8
	li $v0, 4
	syscall
	
	#print string 1
	li $v0, 4
	la $a0, prompt6
	syscall
	la $a0, original
	li $v0, 4
	syscall
	
	#print string 2
	li $v0, 4
	la $a0, prompt7
	syscall
	la $a0, copy
	li $v0, 4
	syscall
	
	#set stack for copy string
	addi $sp, $sp, -8
	la $a0, original
	la $a1, copy
	sw $a0, 4($sp)
	sw $a1, 0($sp)

	jal strcpy
	add $sp, $sp 8
	
	#prompt after swap:
	la $a0, prompt9
	li $v0, 4
	syscall
	
	#print string 1
	li $v0, 4
	la $a0, prompt6
	syscall
	la $a0, original
	li $v0, 4
	syscall
	
	#print string 2
	li $v0, 4
	la $a0, prompt7
	syscall
	la $a0, copy
	li $v0, 4
	syscall
	
	
	
li $v0, 10
syscall	
	
	
swap:
	xor $t0, $t0, $t0
	xor $t1, $t1, $t1
	xor $t2, $t2, $t2
	xor $t3, $t3, $t3

	lw $t0, 0($sp)
	lw $t1, 4($sp)
	
	lw $t2, 0($t0)
	lw $t3, 0($t1)
	
	sw $t3, 0($t0)
	sw $t2, 0($t1)

jr $ra

strcpy:
	lw $a0, 4($sp)
	lw $a1, 0($sp)
	
	top:
	lb $t0, 0($a0)
	beq $t0, $0, done
	sb $t0, 0($a1)
	
	addi $a0, $a0, 1
	addi $a1, $a1, 1
	addi $v0, $v0, 1
	
	j top
	
done:
jr $ra
	


	
	
	
	
	
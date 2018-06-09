.data
	tid: .space 4    # tid
	tcb0: .space 124
	tcb1: .space 124

.text

main:
	la $a0, tcb0
	la $a1, task0
	sw $a1, 0($a0)
	la $a0, tcb1
	la $a1, task1
	sw $a1, 0($a0)
	add $s0, $0, $0

task0: 
	addi $t7, $0, 10000   # timing loop
loop0:                      
	addi $t7, $t7, -1       
	bgt  $t7, 0, loop0     
	
	li $v0, 11
	addi $a0, $0, 'x'
	syscall
	jal ts  
	j task0
	
task1: 
	addi $t6, $0, 10000  # timing loop
loop1:                      
	addi $t6, $t6, -1      
	bgt  $t6, 0, loop1     
	
	li $v0, 11
	addi $a0, $0, 'y'
	syscall
	jal ts  
	j task1
	
ts:
	addi $sp, $sp, -4
	sw $s0, 0($sp)
	la $s0, tid
	lw $s0, 0($s0)
	bne $s0, 0, one
	
zero:
	la $s0, tcb0
	sw $ra, 0($s0)
	sw $v0, 4($s0)
	sw $v1, 8($s0)
	sw $a0, 12($s0)
	sw $a1, 16($s0)
	sw $a2, 20($s0)
	sw $a3, 24($s0)
	sw $t0, 28($s0)
	sw $t1, 32($s0)
	sw $t2, 36($s0)
	sw $t3, 40($s0)
	sw $t4, 44($s0)
	sw $t5, 48($s0)
	sw $t6, 52($s0)
	sw $t7, 56($s0)
	sw $t8, 60($s0)
	sw $t9, 64($s0)
	#sw $s0, 68($s0)
	sw $s1, 72($s0)
	sw $s2, 76($s0)
	sw $s3, 80($s0)
	sw $s4, 84($s0)
	sw $s5, 88($s0)
	sw $s6, 92($s0)
	sw $s7, 96($s0)
	sw $s8, 100($s0)
	sw $gp, 104($s0)
	
	lw $t0, 0($sp)
	sw $t0, 68($s0)
	la $s0, tid
	lw $s1, 0($s0)
	addi $s1, $0, 1
	sw $s1, 0($s0)
	la $s0, tcb1
	
	lw $ra, 0($s0)
	lw $v0, 4($s0)
	lw $v1, 8($s0)
	lw $a0, 12($s0)
	lw $a1, 16($s0)
	lw $a2, 20($s0)
	lw $a3, 24($s0)
	lw $t0, 28($s0)
	lw $t1, 32($s0)
	lw $t2, 36($s0)
	lw $t3, 40($s0)
	lw $t4, 44($s0)
	lw $t5, 48($s0)
	lw $t6, 52($s0)
	lw $t7, 56($s0)
	lw $t8, 60($s0)
	lw $t9, 64($s0)
	#lw $s0, 68($s0)
	lw $s1, 72($s0)
	lw $s2, 76($s0)
	lw $s3, 80($s0)
	lw $s4, 84($s0)
	lw $s5, 88($s0)
	lw $s6, 92($s0)
	lw $s7, 96($s0)
	lw $s8, 100($s0)
	lw $gp, 104($s0)
	lw $s0, 68($s0)

	addi $sp, $sp, 4
	jr $ra
one:
	la $s0, tcb1
	sw $ra, 0($s0)
	sw $v0, 4($s0)
	sw $v1, 8($s0)
	sw $a0, 12($s0)
	sw $a1, 16($s0)
	sw $a2, 20($s0)
	sw $a3, 24($s0)
	sw $t0, 28($s0)
	sw $t1, 32($s0)
	sw $t2, 36($s0)
	sw $t3, 40($s0)
	sw $t4, 44($s0)
	sw $t5, 48($s0)
	sw $t6, 52($s0)
	sw $t7, 56($s0)
	sw $t8, 60($s0)
	sw $t9, 64($s0)
	#sw $s0, 68($s0)
	sw $s1, 72($s0)
	sw $s2, 76($s0)
	sw $s3, 80($s0)
	sw $s4, 84($s0)
	sw $s5, 88($s0)
	sw $s6, 92($s0)
	sw $s7, 96($s0)
	sw $s8, 100($s0)
	sw $gp, 104($s0)
	
	lw $t0, 0($sp)
	sw $t0, 68($s0)
	la $s0, tid
	lw $s1, 0($s0)
	addi $s1, $0, 0
	sw $s1, 0($s0)

	la $s0, tcb0
	lw $ra, 0($s0)
	lw $v0, 4($s0)
	lw $v1, 8($s0)
	lw $a0, 12($s0)
	lw $a1, 16($s0)
	lw $a2, 20($s0)
	lw $a3, 24($s0)
	lw $t0, 28($s0)
	lw $t1, 32($s0)
	lw $t2, 36($s0)
	lw $t3, 40($s0)
	lw $t4, 44($s0)
	lw $t5, 48($s0)
	lw $t6, 52($s0)
	lw $t7, 56($s0)
	lw $t8, 60($s0)
	lw $t9, 64($s0)
	#lw $s0, 68($s0)
	lw $s1, 72($s0)
	lw $s2, 76($s0)
	lw $s3, 80($s0)
	lw $s4, 84($s0)
	lw $s5, 88($s0)
	lw $s6, 92($s0)
	lw $s7, 96($s0)
	lw $s8, 100($s0)
	lw $gp, 104($s0)
	lw $s0, 68($s0)
	
	addi $sp, $sp, 4
	jr $ra
